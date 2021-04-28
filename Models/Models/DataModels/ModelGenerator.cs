using System;

namespace BookMyShow.Models
{
 
    public class Booking
    {
        public int Id { get; set; }
        public int NoOfSeats { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public int ShowId { get; set; }
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pincode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string RunningTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class Seat
    {
        public int Id { get; set; }
        public short Status { get; set; }
        public int HallId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class Show
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class TheatreHall
    {
        public int Id { get; set; }
        public int TotalSeats { get; set; }
        public int TheatreId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
     
    public class Theatres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfHalls { get; set; }
        public decimal TicketPrice { get; set; }
        public int CityId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
    
    public class TheatreShowsDetailsView
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



