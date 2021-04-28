using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.HallService
{
    public interface IHallService
    {
        IEnumerable<HallDTO> GetHalls();
        HallDTO GetHall(int id);
        void PutHall(int id, HallDTO hall);
        int PostHall(HallDTO hall);
        void DeleteHall(int id);
    }
}
