using bookshop.Models;

namespace bookshop.ViewModels
{
    public class BookTitleViewModel
    {
        public IList<Book> Books { get; set; }
        public IList<Genre> Genres { get; set; }    
        public string BookGenre { get; set; }
        public string SearchString { get; set; }
    }
}
