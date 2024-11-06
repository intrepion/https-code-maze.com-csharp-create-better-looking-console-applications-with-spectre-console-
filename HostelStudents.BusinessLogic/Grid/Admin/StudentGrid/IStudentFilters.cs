namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

// Interface for filtering.
public interface IStudentFilters
{
    // The StudentFilterColumns being filtered on.
    StudentFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The StudentFilterColumns being sorted.
    StudentFilterColumns SortColumn { get; set; }
}
