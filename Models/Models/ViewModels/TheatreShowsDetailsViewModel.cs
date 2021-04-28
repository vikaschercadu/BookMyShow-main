using System;
namespace BookMyShow.Models
{
    public class TheatreShowsDetailsViewModel
    {
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public int NoOfHalls { get; set; }
        public int ShowId { get; set; }
        public DateTime ShowDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int HallId { get; set; }
        public int TotalSeats { get; set; }
    }
}
