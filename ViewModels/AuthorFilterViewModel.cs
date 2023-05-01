using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookshop.ViewModels
{
    public class AuthorFilterViewModel
    {
        public IList<Author> Authors { get; set; }
        public SelectList Nationalities { get; set; }
        public string AuthorNationality { get; set; }
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }

    }
}
