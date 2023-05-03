using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookshop.Data;
using bookshop.Models;
using bookshop.ViewModels;
using System.Collections;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Hosting;
using System.Web;

namespace bookshop.Controllers
{
    public class BooksController : Controller
    {
        private readonly bookshopContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksController(bookshopContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<Book> books = _context.Book.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(x => x.Title.Contains(searchString));
            }

            books = books.Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Genres!).ThenInclude(x => x.Genre);

            var bookTitleVM = new BookTitleViewModel
            {
                Books = await books.ToListAsync(),
                Genres = await _context.Genre.ToListAsync(),
            };

            return View(bookTitleVM);

            //var bookshopContext = _context.Book.Include(b => b.Author);
            //return View(await bookshopContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new BookCreateViewModel
            {
                Book = new Book(),
                GenreList = genres.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.GenreName
                })
            };

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FullName");
            return View(viewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Book);
                await _context.SaveChangesAsync();

                if (viewModel.SelectedGenres != null)
                {
                    foreach (var genreId in viewModel.SelectedGenres)
                    {
                        var bookGenre = new BookGenre { BookId = viewModel.Book.Id, GenreId = genreId };
                        _context.Add(bookGenre);
                    }
                }

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FullName", viewModel.Book.AuthorId);
            viewModel.GenreList = _context.Genre.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.GenreName
            });

            return View(viewModel.Book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = _context.Book.Where(x => x.Id == id).Include(x => x.Genres).First();

            //var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var genres = _context.Genre.AsEnumerable();

            BooksEditViewModel viewmodel = new BooksEditViewModel
            {
                Book = book,
                GenreList = new MultiSelectList(genres, "Id", "GenreName"),
                SelectedGenres = book.Genres!.Select(x => x.GenreId)
            };

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FullName", book.AuthorId);
            return View(viewmodel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BooksEditViewModel viewModel)
        {
            if (id != viewModel.Book?.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Book);
                    await _context.SaveChangesAsync();

                    IEnumerable<int> newGenreList = viewModel.SelectedGenres!;
                    IEnumerable<int> prevGenreList = _context.BookGenre.Where(s => s.BookId == id).Select(s => s.GenreId);
                    IQueryable<BookGenre> toBeRemoved = _context.BookGenre.Where(s => s.BookId == id);

                    if (newGenreList != null)
                    {
                        toBeRemoved = toBeRemoved.Where(s => !newGenreList.Contains(s.GenreId));
                        foreach (int genreId in newGenreList)
                        {
                            if (!prevGenreList.Any(s => s == genreId))
                            {
                                _context.BookGenre.Add(new BookGenre { GenreId = genreId, BookId = id });
                            }
                        }
                    }
                    _context.BookGenre.RemoveRange(toBeRemoved);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(viewModel.Book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FullName", viewModel.Book.AuthorId);
            return View(viewModel);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'bookshopContext.Book'  is null.");
            }

            var bookGenres = await _context.BookGenre.Where(bg => bg.BookId == id).ToListAsync();
            _context.BookGenre.RemoveRange(bookGenres);


            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> AddPicture(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var book = _context.Book
                .Include(x => x.Author)
                .Where(x => x.Id == id).First();

            if(book == null)
            {
                return NotFound();
            }

            CoverViewModel viewmodel = new CoverViewModel
            {
                Book = book,
                CoverPhotoName = book.FrontPage
            };

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FullName", viewmodel.Book.AuthorId);
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPicture(int id, CoverViewModel viewmodel)
        {
            if(id != viewmodel.Book.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    if(viewmodel.CoverPhoto != null)
                    {
                        string uniqueFileName = UploadedFile(viewmodel);
                        viewmodel.Book.FrontPage = uniqueFileName;
                    }
                    else
                    {
                        viewmodel.Book.FrontPage = viewmodel.CoverPhotoName;
                    }

                    _context.Update(viewmodel.Book);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!BookExists(viewmodel.Book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = viewmodel.Book.Id });
            }

            return View(viewmodel);
        }

        private string UploadedFile(CoverViewModel viewmodel)
        {
            string uniqueFileName = null;

            if(viewmodel.CoverPhoto != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures");
                if(!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(viewmodel.CoverPhoto.FileName);
                string fileNameWithPath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    viewmodel.CoverPhoto.CopyTo(stream);
                }
            }
            return uniqueFileName;
        }
    }
}
