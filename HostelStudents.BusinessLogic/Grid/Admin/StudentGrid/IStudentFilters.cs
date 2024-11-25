namespace HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;

public interface IStudentFilters
{
    StudentFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    StudentFilterColumns SortColumn { get; set; }
}
