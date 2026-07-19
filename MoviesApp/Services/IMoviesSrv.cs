using MoviesApp.Data.Models;

namespace MoviesApp.Services
{
    public interface IMoviesSrv
    {
        List<Movie> GetAll();
        Movie? Get(int id);

        void Add(Movie mv);

    }
}
