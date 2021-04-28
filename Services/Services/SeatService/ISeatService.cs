using BookMyShow.Enums;
using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.SeatService
{
    public interface ISeatService
    {
        SeatDTO GetSeat(int id);
        void PutSeat(int id, SeatDTO seat);
        int PostSeat(SeatDTO seat);
        void DeleteSeat(int id);
        int GetBookedSeatsCount(int hallId);
        void HoldSeats(int noOfSeats, int hallId);
        void ConfirmSeats(int noOfseats, int hallId);
        void CancelBooking(int noOfseats, int hallId);
    }
}
