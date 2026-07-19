using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;

namespace MoviesApp.Pages
{
    public class MovieModel : PageModel
    {

        public Movie? movie { get; set; }


        //private ApplicationDBContext _context;

        //public MovieModel(ApplicationDBContext context)
        //{
        //    _context = context;
        //}


        //public void OnGet(int id)
        //{

        //    movie = _context.Movies.FirstOrDefault(n => n.Id == id);

        //}



        private IMoviesSrv _srv;

        public MovieModel(IMoviesSrv srv)
        {
            _srv = srv;
        }


        public void OnGet(int id)
        {

            movie = _srv.Get(id);

        }




    }
}
