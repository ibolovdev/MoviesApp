using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;
using MoviesApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviesApp.Pages
{
    [Authorize]
    //  [Authorize(Policy = "GraduatedOnly")]
    //[Authorize(Roles = "Admin,Manager")]// or
    //[Authorize(Roles = "Admin")]// and
    //[Authorize(Roles = "Manager")]
    public class AddMovieModel : PageModel
    {
        //[BindProperty]
        //public string? Title { get; set; }

        //[BindProperty]
        //public string? Description { get; set; }

        //[BindProperty]
        //public int? Rate { get; set; }



        [BindProperty]
        public Movie? Movie { get; set; }


        //private ApplicationDBContext _context;

        //public AddMovieModel(ApplicationDBContext context)
        //{
        //    _context = context;
        //}


        private IMoviesSrv _srv;

        public AddMovieModel(IMoviesSrv srv)
        {
            _srv = srv;
        }

            public void OnGetMyOnClick()
        {
          //  Title = "Welcome";
        }


        public void OnGet()
        {
           // Title = "Welcome";
        }


        public IActionResult OnPost() 
        {
           // string value = $"{Title} - {Rate} - {Description}";

            string value = $"{Movie.Title} - {Movie.Rate} - {Movie.Description}";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            // return Page();


            var movie = new Movie()
            {
                Title = Movie.Title,
                Rate = Movie.Rate,
                Description = Movie.Description
            };

            //_context.Movies.Add(movie); 
            //_context.SaveChanges(); 

            _srv.Add(movie);


            return Redirect("/Movies");
        }
    }
}
