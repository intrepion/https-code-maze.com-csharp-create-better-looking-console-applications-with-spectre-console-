using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationUserGrid;

public class ApplicationUserGridQueryAdapter
{
    private readonly IApplicationUserFilters controls;

    private readonly Dictionary<ApplicationUserFilterColumns, Expression<Func<ApplicationUser, string>>> expressions =
        new()
        {
            { ApplicationUserFilterColumns.Email, x => x != null && x.Email != null ? x.Email : string.Empty },
            { ApplicationUserFilterColumns.PhoneNumber, x => x != null && x.PhoneNumber != null ? x.PhoneNumber : string.Empty },
            { ApplicationUserFilterColumns.UserName, x => x != null && x.UserName != null ? x.UserName : string.Empty },
        };

    private readonly Dictionary<ApplicationUserFilterColumns, Func<IQueryable<ApplicationUser>, IQueryable<ApplicationUser>>> filterQueries = [];

    public ApplicationUserGridQueryAdapter(IApplicationUserFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { ApplicationUserFilterColumns.Email, x => x.Where(y => y != null && y.Email != null && this.controls.FilterText != null && y.Email.Contains(this.controls.FilterText) ) },
                { ApplicationUserFilterColumns.PhoneNumber, x => x.Where(y => y != null && y.PhoneNumber != null && this.controls.FilterText != null && y.PhoneNumber.Contains(this.controls.FilterText) ) },
                { ApplicationUserFilterColumns.UserName, x => x.Where(y => y != null && y.UserName != null && this.controls.FilterText != null && y.UserName.Contains(this.controls.FilterText) ) },
            };
    }

    public async Task<ICollection<ApplicationUser>> FetchAsync(IQueryable<ApplicationUser> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<ApplicationUser> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<ApplicationUser> FetchPageQuery(IQueryable<ApplicationUser> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<ApplicationUser> FilterAndQuery(IQueryable<ApplicationUser> root)
    {
        var sb = new System.Text.StringBuilder();

        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        if (controls.SortColumn == ApplicationUserFilterColumns.UserName && controls.ShowUserNameFirst)
        {
            sb.Append("(name first) ");
            expression = x => x != null && x.UserName != null ? x.UserName : string.Empty;
        }

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
