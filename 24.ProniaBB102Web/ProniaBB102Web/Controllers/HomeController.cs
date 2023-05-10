using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            HomeVM homeVM = new HomeVM
            {
                Products=await _context.Products.Include(p=>p.ProductImages).ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
