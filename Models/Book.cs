using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? YearPublished { get; set; }
        public int? NumPages { get; set; }

        public string? Description { get; set; }

        [StringLength(50)]
        public string? Publisher { get; set; }

        public string? FrontPage { get; set; }
        public string? DownloadUrl { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<UserBooks>? UserBks { get; set; }
        public ICollection<BookGenre>? Genres { get; set; }
    }
}
