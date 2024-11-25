namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

public interface IHostelFilters
{
    HostelFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    HostelFilterColumns SortColumn { get; set; }
}
