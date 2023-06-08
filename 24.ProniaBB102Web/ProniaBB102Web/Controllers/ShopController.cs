using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Utilities.Exceptions;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            //string result = Request.Cookies["Name"];

            //if (string.IsNullOrEmpty(result)) return NotFound();

            //Response.Cookies.Append("Name", "Yusif", new CookieOptions
            //{
            //    MaxAge = TimeSpan.FromSeconds(50)
            //});


            //HttpContext.Session.SetString("Name", "Azade");
            if (id is null || id < 1) throw new WrongRequestException("Gonderilen Id deyeri duzgun deyil");
          

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Include(p => p.ProductTags).ThenInclude(pt=>pt.Tag)
                .FirstOrDefaultAsync(p=>p.Id==id);

            if (product == null) throw new NotFoundException("Mehsul tapilmadi");

           
            List<Product> products = await _context.Products.Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id).Include(p=>p.ProductImages).ToListAsync();

            DetailVM detailVM = new DetailVM
            {
                Product = product,
                Products = products
            };
            return View(detailVM);
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user is null) return NotFound();

                BasketItem existedItem = await _context.BasketItems
                    .FirstOrDefaultAsync(b=>b.AppUserId==user.Id&&b.ProductId==product.Id&&b.OrderId==null);
                if (existedItem is null)
                {
                    existedItem = new BasketItem
                    {
                        AppUserId = user.Id,
                        ProductId = product.Id,
                        Price = product.Price,
                        Count = 1,

                    };
                    await _context.BasketItems.AddAsync(existedItem);
                }
                else
                {
                    existedItem.Count++;
                }
                await _context.SaveChangesAsync();

               
            }
            else
            {
                List<BasketCookiesItemVM> basket;

                if (Request.Cookies["Basket"] == null)
                {
                    basket = new List<BasketCookiesItemVM>();

                    basket.Add(new BasketCookiesItemVM
                    {
                        Id = product.Id,
                        Count = 1
                    });
                }
                else
                {
                    basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);

                    BasketCookiesItemVM existed = basket.FirstOrDefault(b => b.Id == id);

                    if (existed != null)
                    {
                        existed.Count++;
                    }
                    else
                    {
                        basket.Add(new BasketCookiesItemVM
                        {
                            Id = product.Id,
                            Count = 1
                        });
                    }
                }

                string json = JsonConvert.SerializeObject(basket);
                Response.Cookies.Append("Basket", json);
            }
           

           

            return RedirectToAction("BasketJson", "Cart");
        }



       
    }
}
