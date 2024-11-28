namespace ApplicationNamePlaceholder.BusinessLogic.Grid;

public class PageHelper : IPageHelper
{
    public int PageSize { get; set; } = 20;

    public int Page { get; set; }

    public bool HasPrev => Page > 1;

    public int PrevPage => Page <= 1 ? Page : Page - 1;

    public bool HasNext => Page < PageCount;

    public int NextPage => Page < PageCount ? Page + 1 : Page;

    public int TotalItemCount { get; set; }

    public int PageItems { get; set; }

    public int DbPage => Page - 1;

    public int Skip => PageSize * DbPage;

    public int PageCount => (TotalItemCount + PageSize - 1) / PageSize;
}
