using Library.Models;

namespace Library.ViewModels
{
    public class BookViewModel
    {
        public IEnumerable<Book>? Books { get; set; }
        public PageViewModel PageInfo { get; set; } = null!;
    }
}
