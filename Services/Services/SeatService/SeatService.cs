using BookMyShow.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Dapper;
using BookMyShow.Enums;
using AutoMapper;
using BookMyShow.Services.BookMyShowDBContext;
using System;

namespace BookMyShow.Services.SeatService
{
    public class SeatService : ISeatService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        public SeatService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }

        public SeatDTO GetSeat(int id)
        {
            string query = $"SELECT * FROM Seats WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<SeatDTO>(SqlConnection.Query<SeatDTO>(query).FirstOrDefault());
        }

        public int GetBookedSeatsCount(int hallId)
        {
            string query = @"SELECT COUNT(Id) FROM Seats WHERE HallId=@HallId AND Status=@Status AND IsDeleted=0";
            return SqlConnection.Query<int>(query, new { HallId = hallId, Status = SeatStatus.Booked }).FirstOrDefault();
        }


        public int PostSeat(SeatDTO seat)
        {
            string query = @"INSERT INTO Seats(HallId,Status) VALUES(@HallId,@Status) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<Seat>(seat)).FirstOrDefault();
        }

        public void PutSeat(int id, SeatDTO seat)
        {
            string query = @"UPDATE Seats SET Status=@Status,HallId=@HallId WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<Seat>(seat));
        }

        public void DeleteSeat(int id)
        {
            string query = $"UPDATE Seats SET IsDeleted=1 , DateDeleted=@CurrentDate WHERE Id={id}";
            SqlConnection.Execute(query, new { Id = id , CurrentDate=DateTime.Now});
        }

        public void HoldSeats(int noOfSeats, int hallId)
        {
            string query = @"SELECT * FROM Seats WHERE HallId=@HallId AND Status=@Status AND IsDeleted=0";
            List<SeatDTO> seats = Mapper.Map<List<SeatDTO>>(SqlConnection.Query<Seat>(query, new { HallId = hallId, Status = (int)SeatStatus.Available }).ToList());
            if (seats.Count >= noOfSeats)
            {
                for (int i = 0; i < noOfSeats; i++)
                {
                    query = @"UPDATE Seats SET Status=@Status, HallId=@HallId WHERE Id=@Id";
                    SqlConnection.Execute(query, new { HallId = hallId, Id = seats[i].Id, Status = (int)SeatStatus.OnHold });
                }
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    query = @"UPDATE Seats SET Status=@Status, HallId=@HallId WHERE Id=@Id";
                    SqlConnection.Execute(query, new { HallId = hallId, Id = seats[i].Id, Status = (int)SeatStatus.OnHold });
                }
                for (int i = 0; i < noOfSeats - seats.Count; i++)
                {
                    query = @"INSERT INTO Seats(HallId,Status) VALUES(@HallId,@Status)";
                    SqlConnection.Execute(query, new { HallId = hallId, Status = (int)SeatStatus.OnHold });
                }
            }
        }

        public void ConfirmSeats(int noOfSeats, int hallId)
        {
            string query = @"SELECT * FROM Seats WHERE HallId=@HallId AND Status=@Status AND IsDeleted=0";
            var seats1 = SqlConnection.Query<Seat>(query, new { HallId = hallId, Status = (int)SeatStatus.OnHold }).ToList();
            List<SeatDTO> seats = Mapper.Map<List<SeatDTO>>(seats1);
            for (int i = 0; i < seats.Count; i++)
            {
                query = @"UPDATE Seats SET Status=@Status,HallId=@HallId WHERE Id=@Id";
                SqlConnection.Execute(query, new { HallId = hallId, Id = seats[i].Id, Status = (int)SeatStatus.Booked });
            }

        }
        public void CancelBooking(int noOfSeats, int hallId)
        {
            string query = @"SELECT * FROM Seats WHERE HallId=@HallId and Status=@Status AND IsDeleted=0";
            List<SeatDTO> seats = Mapper.Map<List<SeatDTO>>(SqlConnection.Query<Seat>(query, new
            {
                HallId = hallId,
                Status = (int)SeatStatus.OnHold
            }).ToList());
            for (int i = 0; i < seats.Count; i++)
            {
                query = @"UPDATE Seats SET Status=@Status,HallId=@HallId WHERE Id=@Id";
                SqlConnection.Execute(query, new { HallId = hallId, Id = seats[i].Id, Status = (int)SeatStatus.Available });
            }
        }
    }
}
