using System.ComponentModel.DataAnnotations;

namespace MovieStoreMVC.Models.Domain
{
    public class Movie
    {
       public int Id { get; set; }

        [Required] public string? Title { get; set; }

        public string? ReleaseYear { get; set; }

        public string? MovieImage { get; set; }

        public string? Cast { get; set; }

        public string? Director { get; set; }   

    }
}
