using Microsoft.AspNetCore.Mvc;
using MovieStoreMVC.Repositories.Abstract;

namespace MovieStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieServices _movieService;

        public HomeController(IMovieServices movieServices)
        {
            this._movieService = movieServices;
        }
        public IActionResult Index()
        {
            var movies = _movieService.List(); 
            return View(movies);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieDetail(int movieId)
        {
            var movie = _movieService.GetByID(movieId);
            return View(movie);
        }


    }
}
