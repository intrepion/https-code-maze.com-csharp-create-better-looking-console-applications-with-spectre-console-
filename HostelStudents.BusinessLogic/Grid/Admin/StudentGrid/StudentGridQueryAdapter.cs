using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HostelStudents.BusinessLogic.Entities;

namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

public class StudentGridQueryAdapter
{
    private readonly IStudentFilters controls;

    private readonly Dictionary<StudentFilterColumns, Expression<Func<Student, string>>> expressions =
        new()
        {
            { StudentFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { StudentFilterColumns.Age, x => x != null ? x.Age.ToString() : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<StudentFilterColumns, Func<IQueryable<Student>, IQueryable<Student>>> filterQueries = [];

    public StudentGridQueryAdapter(IStudentFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { StudentFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<Student>> FetchAsync(IQueryable<Student> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<Student> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<Student> FetchPageQuery(IQueryable<Student> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<Student> FilterAndQuery(IQueryable<Student> root)
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
