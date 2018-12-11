using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vidly.DataContracts;
using Vidly.Models;

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

            var movie = _Context.Movies.Include(c => c.Genre);

            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _Context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);

            if (movie == null)
                HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var _movieModel = new MovieFormViewModel
            {
                Genre = _Context.Genres.ToList()
            };
            return View("MoviesForm", _movieModel);
        }

        public ActionResult Edit(int id)
        {
            var _movieDetails = _Context.Movies.FirstOrDefault(c => c.ID == id);
            if (_movieDetails == null)
                return HttpNotFound();

            var _movieModel = new MovieFormViewModel
            {
                ID = _movieDetails.ID,
                Name = _movieDetails.Name,
                ReleaseDate = _movieDetails.ReleaseDate,
                NoInStock = _movieDetails.NoInStock,
                GenreId = _movieDetails.GenreId,
                Genre = _Context.Genres.ToList()
            };


            return View("MoviesForm", _movieModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new MovieFormViewModel (movie)
                {
                    Genre = _Context.Genres.ToList()
                };
                return View("MoviesForm", viewModel);
            }


            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _Context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _Context.Movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NoInStock = movie.NoInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _Context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}