namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

public class StudentGridControls(IPageHelper pageHelper) : IStudentFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public StudentFilterColumns SortColumn { get; set; } = StudentFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public StudentFilterColumns FilterColumn { get; set; } = StudentFilterColumns.Id;

    public string? FilterText { get; set; }
}
