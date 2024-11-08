﻿namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

// State of grid filters.
public class HostelGridControls(IPageHelper pageHelper) : IHostelFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public HostelFilterColumns SortColumn { get; set; } = HostelFilterColumns.Id;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public HostelFilterColumns FilterColumn { get; set; } = HostelFilterColumns.Id;

    // Text to filter on.
    public string? FilterText { get; set; }
}
