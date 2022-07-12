using Library.Models;
using Library.Models.Data;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;
        public HomeController(ApplicationContext context) => _db = context;

        [HttpGet]
        public async Task<IActionResult> Books(int currentPage = 1)
        {
            IQueryable<Book> books = _db.Books
                .Include(b => b.Author)
                .Include(b => b.Genre);

            int itemCount = 2;

            int count = await books.CountAsync();
            var items = await books.Skip((currentPage - 1) * itemCount).Take(itemCount).ToListAsync();

            PageViewModel pageVM = new PageViewModel(count, currentPage, itemCount);

            BookViewModel bookVM = new BookViewModel
            {
                Books = items,
                PageInfo = pageVM
            };

            return View("/Views/Book/Books.cshtml", bookVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authors = _db.Authors;
            var genres = _db.Genres;
           
            CreatePageViewModel createPageVM = new CreatePageViewModel(authors, genres);

            return View("/Views/Book/Create.cshtml", createPageVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book newBook)
        {
            if (String.IsNullOrEmpty(newBook.Title) || (newBook.Year <= 0 || newBook.Year > DateTime.Now.Year))
            {
                return Content("Неккоректные данные");
            }
            else
            {
                await _db.Books.AddAsync(newBook);
                await _db.SaveChangesAsync();

                return RedirectToAction("Books");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Books");
            }

            var books = _db.Books
                .Include(b => b.Author)
                .Include(b => b.Genre);

            var book = books.FirstOrDefault(b => b.Id == id);

            if(book != null)
            {
                var authors = _db.Authors;
                var genres = _db.Genres;

                EditPageViewModel editPageVM = new EditPageViewModel(book, authors, genres);

                return View("/Views/Book/Edit.cshtml", editPageVM);
            }

            return RedirectToAction("Books");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book editBook)
        {
            if (String.IsNullOrEmpty(editBook.Title) || (editBook.Year <= 0 || editBook.Year > DateTime.Now.Year))
            {
                return Content("Неккоректные данные");
            }
            else
            {
                _db.Entry(editBook).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return RedirectToAction("Books");
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            
            if(book != null)
            {
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                return RedirectToAction("Books");
            }

            return RedirectToAction("Books");
        }
    }
}