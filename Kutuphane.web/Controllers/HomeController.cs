using Kutuphane.Data;
using Microsoft.AspNetCore.Mvc; 
using System.Diagnostics;

namespace Kutuphane.web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}