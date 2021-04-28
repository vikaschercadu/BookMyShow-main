using BookMyShow.Models;
using BookMyShow.Services.MoviesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService MovieService;
        // GET: api/<MoviesController>
        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        [Route("all")]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return MovieService.GetMovies();
        }

        // GET api/<MoviesController>/5
        [Route("{id}")]
        public MovieDTO Get(int id)
        {
            return MovieService.GetMovie(id);
        }

        // POST api/<MoviesController>
        [Authorize(Roles ="Admin")]
        [Route("add")]
        public int Post(MovieDTO movie)
        {
            return MovieService.PostMovie(movie);
        }

        // PUT api/<MoviesController>/5
        [Authorize(Roles = "Admin")]
        [Route("update/{id}")]
        public void Put(int id, MovieDTO movie)
        {
            MovieService.PutMovie(id, movie);
        }

        // DELETE api/<MoviesController>/5
        [Authorize(Roles = "Admin")]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            MovieService.DeleteMovie(id);
        }
    }
}
