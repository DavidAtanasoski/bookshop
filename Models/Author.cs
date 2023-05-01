using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        [StringLength(50)]
        public string? Gender { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
