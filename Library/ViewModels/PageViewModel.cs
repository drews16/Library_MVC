namespace Library.ViewModels
{
    public class PageViewModel
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public PageViewModel(int count, int currentPage, int itemCount)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)itemCount);
        }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
