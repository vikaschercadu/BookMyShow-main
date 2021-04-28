using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.BookingService
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetBookings();
        BookingDTO GetBooking(int id);
        void PutBooking(int id, BookingDTO booking);
        int PostBooking(BookingDTO booking);
        void DeleteBooking(int id);
    }
}
