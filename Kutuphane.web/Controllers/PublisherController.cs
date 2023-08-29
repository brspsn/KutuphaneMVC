using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.web.Controllers
{
    public class PublisherController:Controller
    {
        private readonly ApplicationDbContext _context;
        
        public PublisherController(ApplicationDbContext context)
        {
            _context=context;
        }
        
        public IActionResult Index()
        {
            return View(_context.Publisher.ToList<Publisher>());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add( Publisher publisher)
        {
            _context.Publisher.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            Publisher PublisherTobeDeleted = _context.Publisher.Find(id);
            _context.Publisher.Remove(PublisherTobeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_context.Publisher.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Publisher Publisher)
        {
            _context.Publisher.Update(Publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
