using Library.Models;
using Library.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationContext _db;
        public AuthorController(ApplicationContext context) => _db = context;

        [HttpGet]
        public IActionResult AddAuthor() => PartialView();
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (String.IsNullOrEmpty(author.Name) || String.IsNullOrEmpty(author.Surname))
            {
                return Content("Введины некорректные данные!");
            }
            else
            {
                await _db.Authors.AddAsync(author);
                await _db.SaveChangesAsync();

                return RedirectToAction("Books", "Book");
            }
        }
    }
}
