using BookMyShow.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using AutoMapper;
using BookMyShow.Services.BookMyShowDBContext;
using System;

namespace BookMyShow.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;

        public BookingService(IBookMyShowDbContextService bookMyShowDbContext, IMapper mapper)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }

        public BookingDTO GetBooking(int id)
        {
            string query = $"SELECT * FROM Bookings WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<BookingDTO>(SqlConnection.Query<Booking>(query).FirstOrDefault());
        }

        public IEnumerable<BookingDTO> GetBookings()
        {
            return Mapper.Map<List<BookingDTO>>(SqlConnection.Query<Booking>("SELECT * FROM Bookings WHERE IsDeleted=0").ToList());
        }

        public int PostBooking(BookingDTO booking)
        {
            string query = @"INSERT INTO Bookings(NoOfSeats,BookingDate,TimeSlot,ShowId,UserId) VALUES(@NoOfSeats,@Date,@TimeSlot,@ShowId,@UserId) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<Booking>(booking)).FirstOrDefault();
        }

        public void PutBooking(int id, BookingDTO booking)
        {
            string query = @"UPDATE Bookings SET NoOfSeats=@NoOfSeats,BookingDate=@Date,TimeSlot=@TimeSlot,UserId=@UserId,ShowId=@ShowId WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<Booking>(booking));
        }

        public void DeleteBooking(int id)
        {
            string query = @"UPDATE Bookings SET IsDeleted=1 and DateDeleted=@CurrentDate WHERE Id=@Id";
            SqlConnection.Execute(query, new { Id = id, CurrentDate=DateTime.Now });
        }
    }
}
