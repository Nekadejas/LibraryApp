﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set;}

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set;}
        public MembershipType MembershipType { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}