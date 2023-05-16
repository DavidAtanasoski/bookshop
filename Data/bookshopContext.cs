using Microsoft.EntityFrameworkCore;
using bookshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using bookshop.Areas.Identity.Data;

namespace bookshop.Data
{
    public class BookshopContext : IdentityDbContext<bookshopUser>
    {
        public BookshopContext (DbContextOptions<BookshopContext> options)
            : base(options)
        {
        }

        public DbSet<bookshop.Models.Author> Author { get; set; } = default!;

        public DbSet<bookshop.Models.Book> Book { get; set; } = default!;

        public DbSet<bookshop.Models.BookGenre> BookGenre { get; set; } = default!;

        public DbSet<bookshop.Models.Genre> Genre { get; set; } = default!;

        public DbSet<bookshop.Models.Review> Review { get; set; } = default!;

        public DbSet<bookshop.Models.UserBooks> UserBooks { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookGenre>()
        //        .HasOne<Book>(b => b.Book)
        //        .WithMany(b => b.Genres)
        //        .HasForeignKey(b => b.BookId);
        //    //.OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<BookGenre>()
        //        .HasOne<Genre>(b => b.Genre)
        //        .WithMany(b => b.Books)
        //        .HasForeignKey(b => b.GenreId);
        //    //.OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Book>()
        //        .HasOne<Author>(b => b.Author)
        //        .WithMany(b => b.Books)
        //        .HasForeignKey(b => b.AuthorId);

        //    modelBuilder.Entity<Book>()
        //        .HasMany(b => b.Reviews)
        //        .WithOne(b => b.Book)
        //        .HasForeignKey(b => b.BookId);

        //    modelBuilder.Entity<Book>()
        //        .HasMany(b => b.UserBks)
        //        .WithOne(b => b.Book)
        //        .HasForeignKey(b => b.BookId);

        //}
    }
}
