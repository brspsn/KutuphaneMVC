using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.web.Controllers
{
    public class BookController : Controller
    {
        //dependency injection ile contexti çekiyoruz
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context) 
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View(_context.Books.Include(b => b.Publishers).Include(b => b.Authors).Include(b=>b.Category).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
