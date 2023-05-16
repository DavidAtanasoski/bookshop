using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Year Published")]
        public int? YearPublished { get; set; }

        [Display(Name = "Number of Pages")]
        public int? NumPages { get; set; }

        public string? Description { get; set; }

        [StringLength(50)]
        public string? Publisher { get; set; }

        [Display(Name = "Front page")]
        public string? FrontPage { get; set; }

        [Display(Name = "Download URL")]
        public string? DownloadUrl { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<UserBooks>? UserBks { get; set; }
        public ICollection<BookGenre>? Genres { get; set; }
    }
}
