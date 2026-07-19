using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Services
{
    public class MoviesService : IMoviesSrv
    {



        public List<Movie> movies { get; set; }





        private ApplicationDBContext _context;

        public MoviesService(ApplicationDBContext context)
        {
            _context = context;
        }



        void IMoviesSrv.Add(Movie mv)
        {
            _context.Movies.Add(mv);
            _context.SaveChanges(); 
        }

        List<Movie> IMoviesSrv.GetAll()
        {
            return _context.Movies.ToList();
        }

        Movie? IMoviesSrv.Get(int id)
        {
           Movie? movie = _context.Movies.FirstOrDefault(n => n.Id == id);
            return movie;
        }
    }
}
