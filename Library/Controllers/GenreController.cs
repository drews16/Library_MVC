using Library.Models;
using Library.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationContext _db;
        public GenreController(ApplicationContext context) => _db = context;

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGenre(Genre genre)
        {
            if(String.IsNullOrEmpty(genre.GenreName))
            {
                return Content("Некорректные данные!");
            }
            else
            {
                await _db.Genres.AddAsync(genre);
                await _db.SaveChangesAsync();

                return RedirectToAction("Books", "Book");
            }
        }
    }
}
