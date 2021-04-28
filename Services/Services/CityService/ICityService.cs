using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.CityService
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetCities();
        CityDTO GetCity(int id);
        void PutCity(int id, CityDTO city);
        int PostCity(CityDTO city);
        void DeleteCity(int id);
    }
}
