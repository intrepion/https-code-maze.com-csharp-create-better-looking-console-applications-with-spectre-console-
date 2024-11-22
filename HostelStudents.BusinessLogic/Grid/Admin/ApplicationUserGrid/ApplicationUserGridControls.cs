namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationUserGrid;

public class ApplicationUserGridControls(IPageHelper pageHelper) : IApplicationUserFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public bool ShowUserNameFirst { get; set; }

    public ApplicationUserFilterColumns SortColumn { get; set; } = ApplicationUserFilterColumns.UserName;

    public bool SortAscending { get; set; } = true;

    public ApplicationUserFilterColumns FilterColumn { get; set; } = ApplicationUserFilterColumns.UserName;

    public string? FilterText { get; set; }
}
