using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; }

        public ICollection<BookGenre>? Books { get; set; }
    }
}
