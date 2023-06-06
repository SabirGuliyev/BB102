using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context,UserManager<AppUser> userManager)
        {
           _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            List<BasketItemVM> basketItems = new List<BasketItemVM>();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user is null) return NotFound();

                List<BasketItem> userItems = await _context.BasketItems
                    .Where(b => b.AppUserId == user.Id)
                    .Include(b => b.Product)
                    .ThenInclude(p => p.ProductImages.Where(pi => pi.IsPrimary == true))
                    .ToListAsync();
                foreach (BasketItem item in userItems)
                {
                    basketItems.Add(new BasketItemVM
                    {
                        Id = item.ProductId,
                        Count = item.Count,
                        Price = item.Price,
                        Image = item.Product.ProductImages[0].ImageUrl

                    });
                }
            }
            else
            {
                List<BasketCookiesItemVM> basket;


                string json = Request.Cookies["Basket"];

                if (!String.IsNullOrEmpty(json))
                {
                    basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(json);
                }
                else
                {
                    basket = new List<BasketCookiesItemVM>();
                }



                foreach (var cookie in basket)
                {
                    Product product = await _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == cookie.Id);

                    if (product == null)
                    {
                        basket.Remove(cookie);
                        continue;
                    }

                    BasketItemVM itemVM = new BasketItemVM
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.ProductImages.FirstOrDefault().ImageUrl,
                        Count = cookie.Count
                    };

                    basketItems.Add(itemVM);

                }
            }


            return View(basketItems);
        }
    }
}
