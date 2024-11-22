namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationRoleGrid;

public class ApplicationRoleGridControls(IPageHelper pageHelper) : IApplicationRoleFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public ApplicationRoleFilterColumns SortColumn { get; set; } = ApplicationRoleFilterColumns.Name;

    public bool SortAscending { get; set; } = true;

    public ApplicationRoleFilterColumns FilterColumn { get; set; } = ApplicationRoleFilterColumns.Name;

    public string? FilterText { get; set; }
}
