namespace Library.Models
{
    public class Genre
    {
        public int Id { get; private set; }
        public string GenreName { get; set; } = null!;
        public List<Book> Books { get; set; } = null!;
    }
}
