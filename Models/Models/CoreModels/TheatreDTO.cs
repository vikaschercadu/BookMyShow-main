namespace BookMyShow.Models
{
    public class TheatreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfHalls { get; set; }
        public decimal TicketPrice { get; set; }
        public int CityId { get; set; }
    }
}
