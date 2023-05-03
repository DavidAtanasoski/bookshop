using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookshop.ViewModels
{
    public class CoverViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoName { get; set; }
    }
}
