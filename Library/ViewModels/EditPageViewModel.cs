using Library.Models;

namespace Library.ViewModels
{
    public class EditPageViewModel
    {
        public Book Book { get; set; } = null!;
        public IEnumerable<Author> Authors { get; set; } = null!;
        public IEnumerable<Genre> Genres { get; set; } = null!;
        public EditPageViewModel(Book book, IEnumerable<Author> authors, IEnumerable<Genre> genres)
        {
            Book = book;
            Authors = authors;
            Genres = genres;
        }
    }
}
