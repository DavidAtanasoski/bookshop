using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class UserBooks
    {
        public int Id { get; set; }

        [StringLength(450)]
        public string AppUser { get; set; } 

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
