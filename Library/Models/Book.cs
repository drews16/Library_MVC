using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Column("Author_Id")]
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        [Column("Genre_Id")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int Year { get; set; }        
    }
}
