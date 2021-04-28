using BookMyShow.Enums;

namespace BookMyShow.Models
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public SeatStatus Status { get; set; }      
        public int HallId { get; set; }
    }
}
