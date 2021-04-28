using BookMyShow.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using AutoMapper;
using BookMyShow.Services.BookMyShowDBContext;
using System;

namespace BookMyShow.Services.ShowService
{
    public class ShowService : IShowService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        public ShowService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }

        public ShowDTO GetShow(int id)
        {
            string query = $"SELECT * FROM Shows WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<ShowDTO>(SqlConnection.Query<Show>(query).FirstOrDefault());
        }

        public IEnumerable<ShowDTO> GetShows()
        {
            return Mapper.Map<List<ShowDTO>>(SqlConnection.Query<Show>("SELECT * FROM Shows WHERE IsDeleted=0").ToList());
        }

        public int PostShow(ShowDTO show)
        {
            string query = @"INSERT INTO Shows(Date,StartTime,EndTime,HallId,MovieId) VALUES(@Date,@StartTime,@EndTime,@HallId,@MovieId) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<Show>(show)).FirstOrDefault();
        }

        public void PutShow(int id, ShowDTO show)
        {
            string query = @"UPDATE Shows SET ShowDate=@Date,StartTime=@StartTime,EndTime=@EndTime,HallId=@HallId,MovieId=@MovieId WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<Show>(show));
        }

        public void DeleteShow(int id)
        {
            string query = $"UPDATE Shows SET IsDeleted=1, DateDeleted=@CurrentDate WHERE Id={id}";
            SqlConnection.Execute(query, new { Id = id, CurrentDate=DateTime.Now });
        }
    }
}
