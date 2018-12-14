using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Vidly.BusinessRules;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [DisplayName("Date of Birth")]
        [CustomerAgeForMemberShip]
        public DateTime? Birthdate { get; set; }


        public bool IsSubscribedToNewsLetter { get; set; }


        public MembershipTypeDto MembershipType { get; set; } 
        // this is called as naviagtion property because it allows us to naviagte from one type to another
        //this is useful when we want to load objects and its related objects from db


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}