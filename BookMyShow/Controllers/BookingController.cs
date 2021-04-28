using BookMyShow.Models;
using BookMyShow.Services.BookingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase      
    {
        private readonly IBookingService BookingService;
        public BookingController(IBookingService bookingService)
        {
            BookingService = bookingService;
        }
        // GET: api/<BookingController>
        [Route("all")]
        public IEnumerable<BookingDTO> GetBookings()
        {
            return BookingService.GetBookings();
        }

        // GET api/<BookingController>/5
        [Route("{id}")]
        public BookingDTO GetBooking(int id)
        {
            return BookingService.GetBooking(id);
        }

        [Authorize]
        [Route("add")]
        public int PostBooking(BookingDTO booking)
        {
            return BookingService.PostBooking(booking);
        }

        // PUT api/<BookingController>/5
        [Authorize (Roles ="Admin")]
        [Route("update/{id}")]
        public void PutBooking(int id, BookingDTO booking)
        {
            BookingService.PutBooking(id, booking);
        }

        // DELETE api/<BookingController>/5
        [Authorize (Roles ="Admin")]
        [HttpDelete("delete/{id}")]
        public void DeleteBooking(int id)
        {
            BookingService.DeleteBooking(id);
        }
    }
}
