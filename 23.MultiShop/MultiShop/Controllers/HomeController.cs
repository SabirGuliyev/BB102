using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels;

namespace MultiShop.Controllers
{
    public class HomeController:Controller
    {
        public readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            //_context.AddRange(slides);
            //_context.SaveChanges();      

            HomeVM homeVM = new HomeVM
            {
                Slides = _context.Slides.OrderBy(s => s.Order).Take(3).ToList(),
                Products = _context.Products.Include(p=>p.Category).ToList(),
                Categories=_context.Categories.Include(c=>c.Products).ToList()
            };

            return View(homeVM);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is null) return NotFound();
         
            return View(product);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
