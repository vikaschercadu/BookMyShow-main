using AutoMapper;
using BookMyShow.Models;
using BookMyShow.Services.BookMyShowDBContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookMyShow.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly IMapper Mapper;
        private readonly IBookMyShowDbContextService BookMyShowDbContext;
        private readonly IDbConnection SqlConnection;
        public CityService(IMapper mapper, IBookMyShowDbContextService bookMyShowDbContext)
        {
            Mapper = mapper;
            BookMyShowDbContext = bookMyShowDbContext;
            SqlConnection = BookMyShowDbContext.GetDbConnection();
        }

        public IEnumerable<CityDTO> GetCities()
        {
            var cities = SqlConnection.Query<City>("SELECT * FROM Cities WHERE IsDeleted=0").ToList();
            return Mapper.Map<List<CityDTO>>(cities);
        }

        public CityDTO GetCity(int id)
        {
            string query = $"SELECT * FROM Cities WHERE Id ={id} AND IsDeleted=0";
            return Mapper.Map<CityDTO>(SqlConnection.Query<City>(query).FirstOrDefault());
        }

        public int PostCity(CityDTO city)
        {
            string query = @"INSERT INTO Cities(Name,Pincode) VALUES(@Name,@Pincode) SELECT CAST(SCOPE_IDENTITY() as int)";
            return SqlConnection.Query<int>(query, Mapper.Map<City>(city)).FirstOrDefault();
        }

        public void PutCity(int id, CityDTO city)
        {
            string query = @"UPDATE Cities SET Name=@Name, Pincode=@Pincode WHERE Id=@id";
            SqlConnection.Execute(query, Mapper.Map<City>(city));
        }

        public void DeleteCity(int id)
        {
            string query = @"UPDATE Cities SET IsDeleted=1 , DateDeleted=@CurrentDate WHERE Id=@Id";
            SqlConnection.Execute(query, new { Id=id, CurrentDate=DateTime.Now });
        }
    }
}
