using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Required]
        public DateTime DateAdded
        { get; set; }


        [Required]
        [Display(Name = "No. in stock")]
        [Range(1, 20)]
        public int NoInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}