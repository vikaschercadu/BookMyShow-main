using BookMyShow.Models;
using BookMyShow.Services.HallService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/hall")]
    [ApiController]
    public class HallController : ControllerBase           
    {
        private readonly IHallService HallService;
        public HallController(IHallService hallService)
        {
            HallService = hallService;
        }
        // GET: api/<HallController>
        [Route("all")]
        public IEnumerable<HallDTO> GetHalls()
        {
            return HallService.GetHalls();
        }

        // GET api/<HallController>/5
        [Route("{id}")]
        public HallDTO GetHall(int id)
        {
            return HallService.GetHall(id);
        }

        // POST api/<HallController>
        [Authorize (Roles ="Admin")]
        [Route("add")]
        public int PostHall(HallDTO hall)
        {
            return HallService.PostHall(hall);
        }

        // PUT api/<HallController>/5
        [Authorize (Roles ="Admin")]
        [Route("update/{id}")]
        public void PutHall(int id, HallDTO hall)
        {
            HallService.PutHall(id, hall);
        }

        // DELETE api/<HallController>/5
        [Authorize (Roles ="Admin")]
        [Route("delete/{id}")]
        public void DeleteHall(int id)
        {
            HallService.DeleteHall(id);
        }
    }
}
