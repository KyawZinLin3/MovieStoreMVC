using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreMVC.Models.Domain;
using MovieStoreMVC.Repositories.Abstract;
using MovieStoreMVC.Repositories.Implementation;

namespace MovieStoreMVC.Controllers
{
    //[Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreServices _genreService;
        public GenreController(IGenreServices genreService)
        {
            this._genreService = genreService;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if(!ModelState.IsValid)
                return View(model);
            var result = _genreService.Add(model);
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

        //Edit Genre
        public IActionResult Edit(int id)
        {
            var data = _genreService.GetByID(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Added Failed";
                return View(model);
            }

        }

        public IActionResult GenreList() 
        { 
            var data = this._genreService.List().ToList();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            
            var result = _genreService.Delete(id);
            return RedirectToAction(nameof(GenreList));
            
           

        }
    }
}
