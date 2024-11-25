using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationRoleGrid;

public class ApplicationRoleGridQueryAdapter
{
    private readonly IApplicationRoleFilters controls;

    private readonly Dictionary<ApplicationRoleFilterColumns, Expression<Func<ApplicationRole, string>>> expressions =
        new()
        {
            { ApplicationRoleFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
        };

    private readonly Dictionary<ApplicationRoleFilterColumns, Func<IQueryable<ApplicationRole>, IQueryable<ApplicationRole>>> filterQueries = [];

    public ApplicationRoleGridQueryAdapter(IApplicationRoleFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { ApplicationRoleFilterColumns.Name, x => x.Where(y => y != null && y.Name != null && this.controls.FilterText != null && y.Name.Contains(this.controls.FilterText) ) },
            };
    }

    public async Task<ICollection<ApplicationRole>> FetchAsync(IQueryable<ApplicationRole> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<ApplicationRole> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<ApplicationRole> FetchPageQuery(IQueryable<ApplicationRole> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<ApplicationRole> FilterAndQuery(IQueryable<ApplicationRole> root)
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

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
