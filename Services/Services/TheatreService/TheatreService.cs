using AutoMapper;
using BookMyShow.Models;
using BookMyShow.Services.BookMyShowDBContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookMyShow.Services.TheatreService
{
    public class TheatreService : ITheatreService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        public TheatreService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }

        public TheatreDTO GetTheatre(int id)
        {
            string query = $"SELECT * FROM Theatres WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<TheatreDTO>(SqlConnection.Query<Theatres>(query).FirstOrDefault());
        }

        public IEnumerable<TheatreDTO> GetTheatres()
        {
            return Mapper.Map<List<TheatreDTO>>(SqlConnection.Query<Theatres>("SELECT * FROM Theatres WHERE IsDeleted=0").ToList());

        }

        public IEnumerable<TheatreShowsDetailsViewModel> GetTheatreShowsDetails(int cityId, int movieId)
        {
            string query = @"SELECT * FROM TheatreShowsDetailsView" +
                                " WHERE cityId=@CityId AND MovieId=@MovieId ORDER BY TheatreId,StartTime";
            return Mapper.Map<List<TheatreShowsDetailsViewModel>>(SqlConnection.Query<TheatreShowsDetailsView>(query, new { CityId = cityId, MovieId = movieId }).ToList());
        }

        public int PostTheatre(TheatreDTO theatre)
        {
            string query = @"INSERT INTO Theatres(Name, NoOfHalls, CityId, TicketPrice) VALUES(@Name,@NoOfHalls,@CityId,@TicketPrice) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<Theatres>(theatre)).FirstOrDefault();
        }

        public void PutTheatre(int id, TheatreDTO theatre)
        {
            string query = @"UPDATE Theatres SET Name=@Name,NoOfHalls=@NoOfHalls,CityId=@CityId,TicketPrice=@TicketPrice WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<Theatres>(theatre));
        }

        public void DeleteTheatre(int id)
        {
            string query = @"UPDATE Theatres SET IsDeleted=1 , DateDeleted=@CurrentDate WHERE Id=@Id";
            SqlConnection.Execute(query, new { Id = id, CurrentDate = DateTime.Now });
        }
    }
}
