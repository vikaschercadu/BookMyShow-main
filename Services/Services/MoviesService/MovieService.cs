using AutoMapper;
using BookMyShow.Models;
using BookMyShow.Services.BookMyShowDBContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookMyShow.Services.MoviesService
{
    public class MovieService : IMovieService
    {
        private readonly IMapper Mapper;
        private readonly IDbConnection SqlConnection;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        public MovieService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }
        

        public MovieDTO GetMovie(int id)
        {
            string query = $"SELECT * FROM Movies WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<MovieDTO>(SqlConnection.Query<Movie>(query).FirstOrDefault());
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            return Mapper.Map<List<MovieDTO>>(SqlConnection.Query<Movie>("SELECT * FROM Movies WHERE IsDeleted=0").ToList());
        }

        public int PostMovie(MovieDTO movie)
        {
            string query = @"INSERT INTO Movies(Title,Language,Genre,RunningTime,ReleaseDate,ImageUrl) VALUES(@Title,@Language,@Genre,@RunningTime,@ReleaseDate,@ImageUrl) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<Movie>(movie)).FirstOrDefault();
        }

        public void PutMovie(int id, MovieDTO movie)
        {
            string query = @"UPDATE Movies SET Title=@Title,Language=@Language,Genre=@Genre,RunningTime=@RunningTime,ReleaseDate=@ReleaseDate,ImageUrl=@ImageUrl WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<Movie>(movie));
        }

        public void DeleteMovie(int id)
        {
            string query = @"UPDATE Movies SET IsDeleted=1, DateDeleted=@CurrentDate WHERE Id={id}";
            SqlConnection.Execute(query, new { Id = id, CurrentDate=DateTime.Now });
        }
    }
}
