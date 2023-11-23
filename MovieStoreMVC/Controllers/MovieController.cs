using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Repositories.Abstract;
using MovieStoreMVC.Repositories.Implementation;

namespace MovieStoreMVC.Controllers
{
    //[Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieServices _movieService ;
        private readonly IFileServices _fileService;
        private readonly IGenreServices _genService;
        public MovieController(IGenreServices genService,IMovieServices MovieService,IFileServices fileService)
        {
            _movieService = MovieService;
            _fileService = fileService;
            _genService = genService;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = _genService.List().Select(a=>new SelectListItem { Text = a.GenreName,Value = a.Id.ToString()});
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });

            if (!ModelState.IsValid)
                return View(model);
            var fileResult = this._fileService.SaveImage(model.ImageFile);
            if (fileResult.Item1 == 0)
            {
                TempData["msg"] = "File could not saved";
            }
            var imageName = fileResult.Item2;
            model.MovieImage = imageName;
            var result = _movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Added Failed";
                return View(model);
            }
            
        }

        //Edit Movie
        public IActionResult Edit(int id)
        {
            var data = _movieService.GetByID(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Movie model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(MovieList));
            }
            else
            {
                TempData["msg"] = "Added Failed";
                return View(model);
            }

        }

        public IActionResult MovieList() 
        { 
            var data = this._movieService.List();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            
            var result = _movieService.Delete(id);
            return RedirectToAction(nameof(MovieList));
            
           

        }
    }
}
