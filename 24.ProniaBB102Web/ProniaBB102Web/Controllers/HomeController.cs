using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            ViewBag.BasketItems = await _context.BasketItems.Where(b => b.AppUserId == user.Id&&b.OrderId==null).ToListAsync();
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderVM orderVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();
            List<BasketItem> items= await _context.BasketItems.Where(b => b.AppUserId == user.Id && b.OrderId == null).ToListAsync();
            if (!ModelState.IsValid)
            {
                ViewBag.BasketItems = items;
                return View();
            }
            decimal total=0;
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].Count * items[i].Price;
            }
            Order order = new Order
            {
                AppUserId = user.Id,
                Status = null,
                BasketItems = items,
                PurchaseAt=DateTime.Now,
                TotalPrice=total,
                Address=orderVM.Address
                
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();




            return RedirectToAction(nameof(Index));
        }
    }
}
