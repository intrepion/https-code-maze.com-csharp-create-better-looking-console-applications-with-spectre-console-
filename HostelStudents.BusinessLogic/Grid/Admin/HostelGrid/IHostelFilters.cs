namespace ApplicationNamePlaceholder.BusinessLogic.Grid.Admin.EntityNamePlaceholderGrid;

public interface IEntityNamePlaceholderFilters
{
    EntityNamePlaceholderFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    EntityNamePlaceholderFilterColumns SortColumn { get; set; }
}
