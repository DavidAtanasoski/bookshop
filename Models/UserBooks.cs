using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class UserBooks
    {
        public int Id { get; set; }

        [StringLength(450)]
        [Display(Name="User")]
        public string AppUser { get; set; }

        [Display(Name ="Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
