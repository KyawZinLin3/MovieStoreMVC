using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Models.DTO;

namespace MovieStoreMVC.Repositories.Abstract
{
    public interface IGenreServices
    {
        bool Add (Genre model);
        bool Update(Genre model);

        Genre GetByID(int id);

        bool Delete(int id);

       IQueryable<Genre> List();
    }
}
