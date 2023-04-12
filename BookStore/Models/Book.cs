using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required, MaxLength(255)]
        public string Author { get; set; }

        [Display(Name = "In Stock")]
        [Range(1, 20)]
        public int Amount { get; set; }

        [Display(Name = "Release Date")]
        public int AvailableAmount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedToDb { get; set; }
    }
}