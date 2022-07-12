using Library.Models;

namespace Library.ViewModels
{
    public class CreatePageViewModel
    {
        public IEnumerable<Author> Authors { get; set; } = null!;
        public IEnumerable<Genre> Genres { get; set; } = null!;
        public CreatePageViewModel(IEnumerable<Author> authors, IEnumerable<Genre> genres)
        {
            Authors = authors;
            Genres = genres;
        }
    }
}
