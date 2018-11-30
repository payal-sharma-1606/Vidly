using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; } 
        // this is called as naviagtion property because it allows us to naviagte from one type to another
        //this is useful when we want to load objects and its related objects from db

        public byte MembershipTypeId { get; set; }  
    }
}