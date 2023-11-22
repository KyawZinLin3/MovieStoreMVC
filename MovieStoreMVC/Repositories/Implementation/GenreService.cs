using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Repositories.Abstract;
using System.Linq.Expressions;

namespace MovieStoreMVC.Repositories.Implementation
{
    public class GenreService : IGenreServices
    {
        private readonly DatabaseContext ctx;

        public GenreService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Genre model)
        {
            try
            {
                ctx.Genre.Add(model);
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
                    ctx.Genre.Remove(data);
                    ctx.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public Genre GetByID(int id)
        {
            return ctx.Genre.Find(id);
        }

        public IQueryable<Genre> List()
        {
           var data = ctx.Genre.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                ctx.Genre.Update(model);
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
