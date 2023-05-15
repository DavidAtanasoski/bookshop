using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace bookshop.ViewModels
{
    public class BookCreateViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }

        public IFormFile? file { get; set; }
        public IFormFile? fileBook { get; set; }
    }
}
