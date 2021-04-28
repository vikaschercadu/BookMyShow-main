using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.TheatreService
{
    public interface ITheatreService
    {
        IEnumerable<TheatreDTO> GetTheatres();
        TheatreDTO GetTheatre(int id);
        IEnumerable<TheatreShowsDetailsViewModel> GetTheatreShowsDetails(int cityId, int movieId);
        void PutTheatre(int id, TheatreDTO theatre);
        int PostTheatre(TheatreDTO theatre);
        void DeleteTheatre(int id);
    }
}
