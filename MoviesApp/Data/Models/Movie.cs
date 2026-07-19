using System.Text.Json.Serialization;

namespace MoviesApp.Data.Models
{
    public class Movie
    {

        //public int? Id { get; set; }
        
        
        //public string? Title { get; set; }
        //public string? Description { get; set; }
        //public int? Rate { get; set; }

        public int Id { get; set; }


        public string Title { get; set; }//removing ?, causes validation on the page
        public string Description { get; set; }
        public int Rate { get; set; }

    }
}
