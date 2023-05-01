using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookshop.Models;

namespace bookshop.Data
{
    public class bookshopContext : DbContext
    {
        public bookshopContext (DbContextOptions<bookshopContext> options)
            : base(options)
        {
        }

        public DbSet<bookshop.Models.Author> Author { get; set; } = default!;

        public DbSet<bookshop.Models.Book> Book { get; set; } = default!;

        public DbSet<bookshop.Models.BookGenre> BookGenre { get; set; } = default!;

        public DbSet<bookshop.Models.Genre> Genre { get; set; } = default!;

        public DbSet<bookshop.Models.Review> Review { get; set; } = default!;

        public DbSet<bookshop.Models.UserBooks> UserBooks { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>()
                .HasOne<Book>(b => b.Book)
                .WithMany(b => b.Genres)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne<Genre>(b => b.Genre)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<Book>()
                .HasOne<Author>(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Reviews)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.UserBks)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

        }
    }
}
