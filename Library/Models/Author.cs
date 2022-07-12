namespace Library.Models
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public List<Book> Books { get; set; } = null!;
    }
}
