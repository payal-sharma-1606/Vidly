using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Movies
        public IHttpActionResult GetMovies()
        {
            var _dto = _context.Movies.Include(c => c.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(_dto);
        }

        // GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (Movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }

        // POST /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            _context.Movies.Add(Movie);
            _context.SaveChanges();

            MovieDto.ID = Movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + Movie.ID), MovieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var MovieInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (MovieInDb == null)
                return NotFound();

            Mapper.Map(MovieDto, MovieInDb);

            _context.SaveChanges();

            return Ok("Movie Details for :" + MovieDto.Name + " updated successfully.");
        }

        // DELETE /api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (MovieInDb == null)
                return NotFound();

            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
            return Ok("Movie :" + MovieInDb.Name + " is Deleted successfully");
        }
    }
}
