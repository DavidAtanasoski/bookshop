﻿using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookshop.ViewModels
{
    public class BooksEditViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
    }
}
