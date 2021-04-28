using System;
namespace BookMyShow.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int NoOfSeats { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public int ShowId { get; set; }
        public string UserId { get; set; }
    }
}
