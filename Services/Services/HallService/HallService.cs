using BookMyShow.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using AutoMapper;
using BookMyShow.Services.BookMyShowDBContext;
using System;

namespace BookMyShow.Services.HallService
{
    public class HallService : IHallService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        public HallService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }
        

        public HallDTO GetHall(int id)
        {
            string query = $"SELECT * FROM TheatreHalls WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<HallDTO>(SqlConnection.Query<TheatreHall>(query).FirstOrDefault());
        }

        public IEnumerable<HallDTO> GetHalls()
        {
            return Mapper.Map<List<HallDTO>>(SqlConnection.Query<TheatreHall>("SELECT * FROM TheatreHalls WHERE ISDeleted=0").ToList());
        }

        public int PostHall(HallDTO hall)
        {
            string query = @"INSERT INTO TheatreHalls(TotalSeats,TheatreId) VALUES(@TotalSeats,@TheatreId) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<TheatreHall>(hall)).FirstOrDefault();
        }

        public void PutHall(int id, HallDTO hall)
        {
            string query = @"UPDATE TheatreHalls SET TotalSeats=@TotalSeats,TheatreId=@TheatreId WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<TheatreHall>(hall));
        }

        public void DeleteHall(int id)
        {
            string query = $"UPDATE TheatreHalls SET IsDeleted=1 , DateDeleted=@CurrentDate WHERE Id=@Id";
            SqlConnection.Execute(query, new { Id = id , CurrentDate=DateTime.Now});
        }
    }
}
