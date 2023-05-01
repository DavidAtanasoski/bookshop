using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace bookshop.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        [StringLength(450)]
        public string AppUser { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public int? Rating { get; set; }
    }
}
