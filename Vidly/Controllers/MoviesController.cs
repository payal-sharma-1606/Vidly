using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.DataContracts;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _Context;
        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }


        protected override void Dispose(bool isDispose)
        {
            _Context.Dispose();
        }
        public ActionResult Index()
        {

            var movies = GetMovies();

            var viewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }


        public List<Movie> GetMovies()
        {
            var movie = new List<Movie>
            {
                new Movie { Name = "Shrek.."},
                new Movie { Name = "Wreck it Ralph.."}
            };

            return movie;
        }

    }
}