namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.ApplicationRoleGrid;

public interface IApplicationRoleFilters
{
    ApplicationRoleFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    ApplicationRoleFilterColumns SortColumn { get; set; }
}
