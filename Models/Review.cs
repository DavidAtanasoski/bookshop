using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace bookshop.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required]
        [StringLength(450)]
        [Display(Name = "Username")]
        public string AppUser { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        [Range(minimum:1, maximum:5)]
        public int? Rating { get; set; }
    }
}
