using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DataContracts
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }



        [Required]
        [Display(Name = "No. in stock")]
        [Range(1, 20)]
        public int? NoInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get { return ID.GetValueOrDefault() != 0 ? "Edit Movie" : "New Movie"; }
        }

        public MovieFormViewModel()
        {
            ID = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NoInStock = movie.NoInStock;
            GenreId = movie.GenreId;
        }
    }
}