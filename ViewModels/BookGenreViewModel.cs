using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookshop.ViewModels
{
    public class BookGenreViewModel
    {
        public IList<Book> Books { get; set; }
        public SelectList Genres { get; set; }  
        public string BookGenre { get; set; }
    }
}
