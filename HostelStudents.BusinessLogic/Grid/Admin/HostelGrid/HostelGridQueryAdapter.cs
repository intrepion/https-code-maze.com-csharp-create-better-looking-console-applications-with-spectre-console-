using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HostelStudents.BusinessLogic.Entities;

namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

// Creates the correct expressions to filter and sort.
public class HostelGridQueryAdapter
{
    // Holds state of the grid.
    private readonly IHostelFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<HostelFilterColumns, Expression<Func<Hostel, string>>> expressions =
        new()
        {
            { HostelFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { HostelFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
            // SortExpressionCodePlaceholder
            // { HostelFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
        };

    // Queryables for filtering.
    private readonly Dictionary<HostelFilterColumns, Func<IQueryable<Hostel>, IQueryable<Hostel>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The IHostelFilters" to use.
    public HostelGridQueryAdapter(IHostelFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { HostelFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
                // { HostelFilterColumns.Name, x => x.Where(y => y != null && y.Name != null && this.controls.FilterText != null && y.Name.Contains(this.controls.FilterText) ) },
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{Hostel} to work from.
    // Returns the resulting ICollection{Hostel}.
    public async Task<ICollection<Hostel>> FetchAsync(IQueryable<Hostel> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{Hostel} to use.
    public async Task CountAsync(IQueryable<Hostel> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{Hostel} to modify.
    // Returns the new IQueryable{Hostel} for a page.
    public IQueryable<Hostel> FetchPageQuery(IQueryable<Hostel> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{Hostel} to start with.
    // Returns the resulting IQueryable{Hostel} with sorts and filters applied.
    private IQueryable<Hostel> FilterAndQuery(IQueryable<Hostel> root)
    {
        var sb = new System.Text.StringBuilder();

        // Apply a filter?
        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        // Apply the expression.
        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        // Return the unfiltered query for total count, and the filtered for fetching.
        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
