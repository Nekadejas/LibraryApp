using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [MaxLength(12)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}