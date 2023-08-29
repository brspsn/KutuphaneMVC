using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context) 
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View(_context.Books.ToList<Book>());
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(Book book)
        {
            _context.Books.Add(book);   
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
