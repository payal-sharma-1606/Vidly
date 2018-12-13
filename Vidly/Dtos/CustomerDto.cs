using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.BusinessRules;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[CustomerAgeForMemberShip]
        public DateTime? Birthdate { get; set; }
    }
}