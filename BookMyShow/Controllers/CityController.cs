using BookMyShow.Models;
using BookMyShow.Services.CityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShow.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        // GET: api/<MoviesController>
        public CityController(ICityService movieService)
        {
            cityService = movieService;
        }
        [Route("all")]
        public IEnumerable<CityDTO> GetCities()
        {
            return cityService.GetCities();
        }

        // GET api/<MoviesController>/5
        [Route("{id}")]
        public CityDTO GetCity(int id)
        {
            return cityService.GetCity(id);
        }

        // POST api/<MoviesController>
        [Route("add")]
        [Authorize(Roles = "Admin")] 
        public int PostCity(CityDTO city)
        {            
            return cityService.PostCity(city);
        }

        // PUT api/<MoviesController>/5
        [Route("update/{id}")]
        [Authorize(Roles = "Admin")]
        public void PutCity(int id, CityDTO city)
        {
            cityService.PutCity(id, city);
        }

        // DELETE api/<MoviesController>/5
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteCity(int id)
        {
            cityService.DeleteCity(id);
        }
    }
}
