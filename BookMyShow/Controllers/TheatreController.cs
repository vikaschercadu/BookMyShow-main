using BookMyShow.Models;
using BookMyShow.Services.TheatreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/theatre")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService TheatreService;
        public TheatreController(ITheatreService theatreService)
        {
            TheatreService = theatreService;
        }
        // GET: api/<TheatreController>
        [Route("all")]
        public IEnumerable<TheatreDTO> GetTheatres()
        {
            return TheatreService.GetTheatres();
        }

        // GET api/<TheatreController>/5
        [Route("{id}")]
        public TheatreDTO GetTheatre(int id)
        {
            return TheatreService.GetTheatre(id);
        }

        [Route("theatreShowsDetails/{cityId}/{movieId}")]
        public IEnumerable<TheatreShowsDetailsViewModel> GetTheatreShowsDetails(int cityId, int movieId)
        {
            return TheatreService.GetTheatreShowsDetails(cityId, movieId);
        }

        // POST api/<TheatreController>
        [Authorize]
        [Route("add")]
        public int PostTheatre(TheatreDTO theatre)
        {
            return TheatreService.PostTheatre(theatre);
        }

        // PUT api/<TheatreController>/5
        [Authorize]
        [Route("update/{id}")]
        public void Put(int id, TheatreDTO theatre)
        {
            TheatreService.PutTheatre(id, theatre);
        }

        // DELETE api/<TheatreController>/5
        [Authorize]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            TheatreService.DeleteTheatre(id);
        }
    }
}
