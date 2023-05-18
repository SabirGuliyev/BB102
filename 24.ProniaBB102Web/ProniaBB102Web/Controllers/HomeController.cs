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
           
           
                //return Content(HttpContext.Session.GetString("Name")+"  " + Request.Cookies["Name"]);
            
            //Response.Cookies.Append("Name", "Yusif",new CookieOptions
            //{
            //    MaxAge=TimeSpan.FromSeconds(50)
            //});


            //HttpContext.Session.SetString("Name", "Azade");
            HomeVM homeVM = new HomeVM
            {
                Products=await _context.Products.Include(p=>p.ProductImages).ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
