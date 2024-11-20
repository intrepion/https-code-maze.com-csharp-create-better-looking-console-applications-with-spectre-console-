using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.EntityNamePlaceholderGrid;

public class EntityNamePlaceholderGridQueryAdapter
{
    private readonly IEntityNamePlaceholderFilters controls;

    private readonly Dictionary<EntityNamePlaceholderFilterColumns, Expression<Func<EntityNamePlaceholder, string>>> expressions =
        new()
        {
            { EntityNamePlaceholderFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<EntityNamePlaceholderFilterColumns, Func<IQueryable<EntityNamePlaceholder>, IQueryable<EntityNamePlaceholder>>> filterQueries = [];

    public EntityNamePlaceholderGridQueryAdapter(IEntityNamePlaceholderFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { EntityNamePlaceholderFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<EntityNamePlaceholder>> FetchAsync(IQueryable<EntityNamePlaceholder> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<EntityNamePlaceholder> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<EntityNamePlaceholder> FetchPageQuery(IQueryable<EntityNamePlaceholder> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<EntityNamePlaceholder> FilterAndQuery(IQueryable<EntityNamePlaceholder> root)
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
