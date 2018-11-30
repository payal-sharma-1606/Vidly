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
            var movie = _Context.Movies.Include(c => c.Genre).SingleOrDefault(c=>c.ID == id);

            if (movie == null)
                HttpNotFound();
            return View(movie);
        }

    }
}