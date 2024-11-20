namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.EntityNamePlaceholderGrid;

public class EntityNamePlaceholderGridControls(IPageHelper pageHelper) : IEntityNamePlaceholderFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public EntityNamePlaceholderFilterColumns SortColumn { get; set; } = EntityNamePlaceholderFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public EntityNamePlaceholderFilterColumns FilterColumn { get; set; } = EntityNamePlaceholderFilterColumns.Id;

    public string? FilterText { get; set; }
}
