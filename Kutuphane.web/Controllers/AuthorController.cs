using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.web.Controllers
{
    public class AuthorController:Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Author> authorList = _context.Author.ToList<Author>();
            return View(authorList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Author authorTobeDeleted = _context.Author.Find(id);
            _context.Author.Remove(authorTobeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_context.Author.Find(id));

        }
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
