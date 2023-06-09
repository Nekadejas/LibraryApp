﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Genre() 
        {
            Books = new List<Book>();
        }
    }
}