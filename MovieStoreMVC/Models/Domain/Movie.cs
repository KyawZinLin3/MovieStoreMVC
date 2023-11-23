using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int> Genres { get; set; }
        public IEnumerable<SelectListItem> GenreList;


    }
}
