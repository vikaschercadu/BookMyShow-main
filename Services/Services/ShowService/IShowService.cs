using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.ShowService
{
    public interface IShowService
    {
        IEnumerable<ShowDTO> GetShows();
        ShowDTO GetShow(int id);
        void PutShow(int id, ShowDTO show);
        int PostShow(ShowDTO show);
        void DeleteShow(int id);
    }
}
