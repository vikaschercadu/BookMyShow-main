using BookMyShow.Models;
using BookMyShow.Services.ShowService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase        
    {
        private readonly IShowService ShowService;
        public ShowController(IShowService showService)
        {
            ShowService = showService;
        }
        // GET: api/<ShowController>
        [Route("all")]
        public IEnumerable<ShowDTO> GetShows()
        {
            return ShowService.GetShows();
        }

        // GET api/<ShowController>/5
        [Route("{id}")]
        public ShowDTO GetShow(int id)
        {
            return ShowService.GetShow(id);
        }

        // POST api/<ShowController>
        [Authorize(Roles ="Admin")]
        [Route("add")]
        public int PostShow(ShowDTO show)
        {
            return ShowService.PostShow(show);
        }

        // PUT api/<ShowController>/5
        [Authorize(Roles = "Admin")]
        [Route("update/{id}")]
        public void PutShow(int id, ShowDTO show)
        {
            ShowService.PutShow(id, show);
        }

        // DELETE api/<ShowController>/5
        [Authorize(Roles = "Admin")]
        [Route("delete/{id}")]
        public void DeleteShow(int id)
        {
            ShowService.DeleteShow(id);
        }
    }
}
