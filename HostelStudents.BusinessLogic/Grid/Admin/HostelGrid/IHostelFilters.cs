﻿namespace HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;

// Interface for filtering.
public interface IHostelFilters
{
    // The HostelFilterColumns being filtered on.
    HostelFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The HostelFilterColumns being sorted.
    HostelFilterColumns SortColumn { get; set; }
}
