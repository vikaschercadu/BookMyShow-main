using System;

namespace BookMyShow.Models
{
    public class ShowDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }  
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}
