using BookMyShow.Models;
using BookMyShow.Services.SeatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/seat")]
    [ApiController]
    public class SeatController : ControllerBase       
    {
        private readonly ISeatService SeatService;
        public SeatController(ISeatService seatService)
        {
            SeatService = seatService;
        }

        // GET api/<SeatController>/5
        [Route("{id}")]
        public SeatDTO GetSeat(int id)
        {
            return SeatService.GetSeat(id);
        }

        [Route("booked/{hallId}")]
        public int GetBookedSeatsCount(int hallId)
        {
            return SeatService.GetBookedSeatsCount(hallId);
        }

        [Authorize]
        [Route("confirm/{noOfSeats}/{hallId}")]
        public void ConfirmSeats(int noOfSeats, int hallId)
        {
            SeatService.ConfirmSeats(noOfSeats, hallId);

        }

        [Authorize]
        [Route("cancel/{noOfSeats}/{hallId}")]
        public void CancelBooking(int noOfSeats, int hallId)
        {
            SeatService.CancelBooking(noOfSeats, hallId);
        }       

        [Route("hold/{noOfSeats}/{hallId}")]
        public void HoldSeats(int noOfSeats, int hallId)
        {
            SeatService.HoldSeats(noOfSeats,hallId);
        }

        // POST api/<SeatController>
        [Route("add")]
        public int PostSeat(SeatDTO seat)
        {
            return SeatService.PostSeat(seat);
        }

        // PUT api/<SeatController>/5
        [Route("update/{id}")]
        public void PutSeat(int id, SeatDTO seat)
        {
            SeatService.PutSeat(id, seat);
        }

        // DELETE api/<SeatController>/5
        [Route("delete/{id}")]
        public void DeleteSeat(int id)
        {
            SeatService.DeleteSeat(id);
        }
    }
}
