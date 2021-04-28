using BookMyShow.Models;
using System.Collections.Generic;

namespace BookMyShow.Services.MoviesService
{
    public interface IMovieService
    {
        IEnumerable<MovieDTO> GetMovies();
        MovieDTO GetMovie(int id);
        void PutMovie(int id, MovieDTO movie);
        int PostMovie(MovieDTO movie);
        void DeleteMovie(int id);
    }
}
