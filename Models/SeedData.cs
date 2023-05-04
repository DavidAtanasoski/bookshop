using bookshop.Data;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new bookshopContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<bookshopContext>>()))
            {
                // Check if exists something in the DB
                if (context.Book.Any())
                {
                    return; // Db has been seeded
                }

                context.Author.AddRange(
                    new Author
                    {
                        FirstName = "Lao",
                        LastName = "Tzu",
                        BirthDate = DateTime.Now,
                        Nationality = "Chinese",
                        Gender = "Male"
                    },
                    new Author
                    {
                        FirstName = "Herman",
                        LastName = "Melville",
                        BirthDate = DateTime.Now,
                        Nationality = "US",
                        Gender = "Male"
                    },
                    new Author
                    {
                        FirstName = "Jane",
                        LastName = "Austen",
                        BirthDate = DateTime.Now,
                        Nationality = "British",
                        Gender = "Female"
                    },
                    new Author
                    {
                        FirstName = "Fyodor",
                        LastName = "Dostoevsky",
                        BirthDate = DateTime.Now,
                        Nationality = "Russian",
                        Gender = "Male"
                    },
                    new Author
                    {
                        FirstName = "Douglas",
                        LastName = "Adams",
                        BirthDate = DateTime.Now,
                        Nationality = "British",
                        Gender = "Male"
                    },
                    new Author
                    {
                        FirstName = "David",
                        LastName = "Atanasoski",
                        BirthDate = DateTime.Parse("2001-04-15"),
                        Nationality = "Macedonian",
                        Gender = "Male"
                    }
                    );
                context.SaveChanges();

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Art of War",
                        YearPublished = 1998,
                        NumPages = 123,
                        Description = "this is a description",
                        Publisher = "london house",
                        FrontPage = "/images/art_of_war.jpg",
                        //FrontPage = "this is a front page",
                        DownloadUrl = "no download url",
                        AuthorId = context.Author.Single(d => d.FirstName == "Lao" && d.LastName == "Tzu").Id
                    },
                    new Book
                    {
                        Title = "Moby Dick",
                        YearPublished = 1851,
                        NumPages = 654,
                        Description = "So Melville wrote of his masterpiece, one of the greatest works of imagination in literary history. In part, Moby-Dick is the story of an eerily compelling madman pursuing an unholy war against a creature as vast and dangerous and unknowable as the sea itself. But more than just a novel of adventure, more than an encyclopaedia of whaling lore and legend, the book can be seen as part of its author's lifelong meditation on America. Written with wonderfully redemptive humour, Moby-Dick is also a profound inquiry into character, faith, and the nature of perception.",
                        Publisher = "Penguin Classics",
                        FrontPage = "/images/moby_dick.jpg",
                        //FrontPage = "this is a front page",
                        DownloadUrl = "no download url",
                        AuthorId = context.Author.Single(d => d.FirstName == "Herman" && d.LastName == "Melville").Id
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        YearPublished = 1813,
                        NumPages = 279,
                        Description = "Since its immediate success in 1813, Pride and Prejudice has remained one of the most popular novels in the English language. Jane Austen called this brilliant work \"her own darling child\" and its vivacious heroine, Elizabeth Bennet, \"as delightful a creature as ever appeared in print.\" The romantic clash between the opinionated Elizabeth and her proud beau, Mr. Darcy, is a splendid performance of civilized sparring. And Jane Austen's radiant wit sparkles as her characters dance a delicate quadrille of flirtation and intrigue, making this book the most superb comedy of manners of Regency England.",
                        Publisher = "Modern Library",
                        FrontPage = "/images/pride_prejudice.jpg",
                        //FrontPage = "this is a front page",
                        DownloadUrl = "no download url",
                        AuthorId = context.Author.Single(d => d.FirstName == "Jane" && d.LastName == "Austen").Id
                    },
                    new Book
                    {
                        Title = "Crime and Punishment",
                        YearPublished = 1866,
                        NumPages = 671,
                        Description = "Raskolnikov, a destitute and desperate former student, wanders through the slums of St Petersburg and commits a random murder without remorse or regret. He imagines himself to be a great man, a Napoleon: acting for a higher purpose beyond conventional moral law. But as he embarks on a dangerous game of cat and mouse with a suspicious police investigator, Raskolnikov is pursued by the growing voice of his conscience and finds the noose of his own guilt tightening around his neck. Only Sonya, a downtrodden sex worker, can offer the chance of redemption.",
                        Publisher = "Penguin",
                        FrontPage = "/images/crime_punishment.jpg",
                        //FrontPage = "this is a front page",
                        DownloadUrl = "no download url",
                        AuthorId = context.Author.Single(d => d.FirstName == "Fyodor" && d.LastName == "Dostoevsky").Id
                    },
                    new Book
                    {
                        Title = "The Hitchhiker's Guide to the Galaxy",
                        YearPublished = 1979,
                        NumPages = 216,
                        Description = "Seconds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor.Together this dynamic pair begin a journey through space aided by quotes from The Hitchhiker's Guide (\"A towel is about the most massively useful thing an interstellar hitchhiker can have\") and a galaxy-full of fellow travelers: Zaphod Beeblebrox--the two-headed, three-armed ex-hippie and totally out-to-lunch president of the galaxy; Trillian, Zaphod's girlfriend (formally Tricia McMillan), whom Arthur tried to pick up at a cocktail party once upon a time zone; Marvin, a paranoid, brilliant, and chronically depressed robot; Veet Voojagig, a former graduate student who is obsessed with the disappearance of all the ballpoint pens he bought over the years.",
                        Publisher = "Del Rey Books",
                        FrontPage = "/images/guide_galaxy.jpg",
                        //FrontPage = "this is a front page",
                        DownloadUrl = "no download url",
                        AuthorId = context.Author.Single(d => d.FirstName == "Douglas" && d.LastName == "Adams").Id
                    }
                    );
                context.SaveChanges();

                context.Genre.AddRange(
                    new Genre
                    {
                        GenreName = "Fiction"
                    },
                    new Genre
                    {
                        GenreName = "Romance"
                    },
                    new Genre
                    {
                        GenreName = "Classics"
                    },
                    new Genre
                    {
                        GenreName = "Science Fiction"
                    }
                    );
                context.SaveChanges();

                context.Review.AddRange(
                    new Review
                    {
                        BookId = context.Book.Single(b => b.Title == "Art of War").Id,
                        AppUser = "David123",
                        Comment = "very nice book. must have.",
                        Rating = 4
                    },
                    new Review
                    {
                        BookId = context.Book.Single(b => b.Title == "Moby Dick").Id,
                        AppUser = "user23",
                        Comment = "interesting classic",
                        Rating = 5
                    },
                    new Review
                    {
                        BookId = context.Book.Single(b => b.Title == "The Hitchhiker's Guide to the Galaxy").Id,
                        AppUser = "petko12",
                        Comment = "A book you must read. I'm speechless!",
                        Rating = 5,
                    },
                    new Review
                    {
                        BookId = context.Book.Single(b => b.Title == "Art of War").Id,
                        AppUser = "AngryBird",
                        Comment = "I didn't like this book! It's terrible!",
                        Rating = 1
                    }
                    );
                context.SaveChanges();

                context.UserBooks.AddRange(
                    new UserBooks
                    {
                        AppUser = "AngryBird",
                        BookId = context.Book.Single(b => b.Title == "Art of War").Id
                    },
                    new UserBooks
                    {
                        AppUser = "petko12",
                        BookId = context.Book.Single(b => b.Title == "The Hitchhiker's Guide to the Galaxy").Id
                    },
                    new UserBooks
                    {
                        AppUser = "user23",
                        BookId = context.Book.Single(b => b.Title == "Moby Dick").Id
                    }
                    );
                context.SaveChanges();

                context.BookGenre.AddRange(
                    new BookGenre { BookId = 1, GenreId = 1 },
                    new BookGenre { BookId = 2, GenreId = 1 },
                    new BookGenre { BookId = 3, GenreId = 2 },
                    new BookGenre { BookId = 4, GenreId = 2 },
                    new BookGenre { BookId = 5, GenreId = 3 },
                    new BookGenre { BookId = 2, GenreId = 3 },
                    new BookGenre { BookId = 3, GenreId = 1 },
                    new BookGenre { BookId = 1, GenreId = 3 }
                    );
                context.SaveChanges();
            }
        }
    }
}
