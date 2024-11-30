using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HostelStudents.BusinessLogic.Entities;

namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

public class HostelGridQueryAdapter
{
    private readonly IHostelFilters controls;

    private readonly Dictionary<HostelFilterColumns, Expression<Func<Hostel, string>>> expressions =
        new()
        {
            { HostelFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { HostelFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<HostelFilterColumns, Func<IQueryable<Hostel>, IQueryable<Hostel>>> filterQueries = [];

    public HostelGridQueryAdapter(IHostelFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { HostelFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<Hostel>> FetchAsync(IQueryable<Hostel> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<Hostel> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<Hostel> FetchPageQuery(IQueryable<Hostel> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<Hostel> FilterAndQuery(IQueryable<Hostel> root)
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
