namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

public class HostelGridControls(IPageHelper pageHelper) : IHostelFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public HostelFilterColumns SortColumn { get; set; } = HostelFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public HostelFilterColumns FilterColumn { get; set; } = HostelFilterColumns.Id;

    public string? FilterText { get; set; }
}
