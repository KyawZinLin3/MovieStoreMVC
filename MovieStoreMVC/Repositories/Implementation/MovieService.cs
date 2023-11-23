using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Models.DTO;
using MovieStoreMVC.Repositories.Abstract;
using System.Linq.Expressions;

namespace MovieStoreMVC.Repositories.Implementation
{
    public class MovieService : IMovieServices
    {
        private readonly DatabaseContext ctx;

        public MovieService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Movie model)
        {
            try
            {
                ctx.Movie.Add(model);
                ctx.SaveChanges();
                foreach (int genreId in model.Genres)
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = model.Id,
                        GenreId = genreId
                    };
                    ctx.MovieGenre.Add(movieGenre);
                }
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            { 
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetByID(id);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    ctx.Movie.Remove(data);
                    ctx.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public Movie GetByID(int id)
        {
            return ctx.Movie.Find(id);
        }

        public MovieListVm List()
        {
           var list = ctx.Movie.AsQueryable();
            var data = new MovieListVm
            {
                MovieList = list
            };
            return data;
        }

        public bool Update(Movie model)
        {
            try
            {
                ctx.Movie.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
