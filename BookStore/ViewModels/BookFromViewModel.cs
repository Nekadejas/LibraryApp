using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.ViewModels
{
    public class BookFromViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [MaxLength(255)]
        [Required]
        public string Author { get; set; }

        [Display(Name = "In Stock")]
        [Required,Range(1,20)]
        public int? Amount { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime AddedToDb { get; set; }
        public string Title 
        {
            get 
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }
        public BookFromViewModel()
        {
            Id = 0;
        }
        public BookFromViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            GenreId = book.GenreId;
            ReleaseDate = book.ReleaseDate;
            Amount = book.Amount;
            
        }
    }
}