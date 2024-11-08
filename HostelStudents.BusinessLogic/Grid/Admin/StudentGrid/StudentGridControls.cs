namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

// State of grid filters.
public class StudentGridControls(IPageHelper pageHelper) : IStudentFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public StudentFilterColumns SortColumn { get; set; } = StudentFilterColumns.Id;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public StudentFilterColumns FilterColumn { get; set; } = StudentFilterColumns.Id;

    // Text to filter on.
    public string? FilterText { get; set; }
}
