using MovieStoreMVC.Models.Domain;

namespace MovieStoreMVC.Models.DTO
{
    public class MovieListVm
    {
        public IQueryable<Movie> MovieList { get; set; }
    }
}
