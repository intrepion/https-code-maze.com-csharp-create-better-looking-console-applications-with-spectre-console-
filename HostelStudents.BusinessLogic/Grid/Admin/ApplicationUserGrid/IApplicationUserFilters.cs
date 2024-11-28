namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationUserGrid;

public interface IApplicationUserFilters
{
    ApplicationUserFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool ShowUserNameFirst { get; set; }

    bool SortAscending { get; set; }

    ApplicationUserFilterColumns SortColumn { get; set; }
}
