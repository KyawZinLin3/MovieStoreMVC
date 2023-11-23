using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Models.DTO;

namespace MovieStoreMVC.Repositories.Abstract
{
    public interface IMovieServices
    {
        bool Add (Movie model);
        bool Update(Movie model);

        Movie GetByID(int id);

        bool Delete(int id);

       MovieListVm List();
    }
}
