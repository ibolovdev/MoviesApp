using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;

namespace MoviesApp.Pages
{

   

    public class MoviesModel : PageModel
    {

        public List<Movie> movies { get; set; }


        private IMoviesSrv _srv;

        public MoviesModel(IMoviesSrv srv)
        {
            _srv = srv;
        }


        //private ApplicationDBContext _context;

        //public MoviesModel(ApplicationDBContext context)
        //{
        //    _context = context;
        //}

        public void OnGet()
        {
            //movies = new List<Movie>()
            //{
            //        new Movie()
            //        {
            //            Id = 1,
            //            Title = "Rambo",
            //            Rate = 10,
            //            Description = "Rambo wanders in the country..."
            //        },
            //         new Movie()
            //        {
            //            Id = 2,
            //            Title = "Rambo2",
            //            Rate = 10,
            //            Description = "Rambo wanders in the country..."
            //        },
            //          new Movie()
            //        {
            //            Id = 3,
            //            Title = "Rambo3",
            //            Rate = 10,
            //            Description = "Rambo wanders in the country..."
            //        },
            //           new Movie()
            //        {
            //            Id = 4,
            //            Title = "Rambo4",
            //            Rate = 10,
            //            Description = "Rambo wanders in the country..."
            //        }
            //};


            //   movies = _context.Movies.ToList();  
            movies = _srv.GetAll();

        }
    }
}
