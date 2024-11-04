using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HostelStudents.BusinessLogic.Entities;

namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

// Creates the correct expressions to filter and sort.
public class StudentGridQueryAdapter
{
    // Holds state of the grid.
    private readonly IStudentFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<StudentFilterColumns, Expression<Func<Student, string>>> expressions =
        new()
        {
            { StudentFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
            // { StudentFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
        };

    // Queryables for filtering.
    private readonly Dictionary<StudentFilterColumns, Func<IQueryable<Student>, IQueryable<Student>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The IStudentFilters" to use.
    public StudentGridQueryAdapter(IStudentFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { StudentFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
                // { StudentFilterColumns.Name, x => x.Where(y => y != null && y.Name != null && this.controls.FilterText != null && y.Name.Contains(this.controls.FilterText) ) },
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{Student} to work from.
    // Returns the resulting ICollection{Student}.
    public async Task<ICollection<Student>> FetchAsync(IQueryable<Student> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{Student} to use.
    public async Task CountAsync(IQueryable<Student> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{Student} to modify.
    // Returns the new IQueryable{Student} for a page.
    public IQueryable<Student> FetchPageQuery(IQueryable<Student> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{Student} to start with.
    // Returns the resulting IQueryable{Student} with sorts and filters applied.
    private IQueryable<Student> FilterAndQuery(IQueryable<Student> root)
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
