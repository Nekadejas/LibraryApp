using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Range(1, 20)]
        public int Amount { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedToDb { get; set; }
        
    }
}