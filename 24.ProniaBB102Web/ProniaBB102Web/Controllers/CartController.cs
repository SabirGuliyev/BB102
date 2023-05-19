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

        public CartController(AppDbContext context)
        {
           _context = context;
        }
        public async Task<IActionResult> Index()
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

            List<BasketItemVM> basketItems = new List<BasketItemVM>();

            foreach (var cookie in basket)
            {
                Product product = await _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p =>p.Id== cookie.Id);

                if (product==null)
                {
                    basket.Remove(cookie);
                    continue;
                }
               
                BasketItemVM itemVM = new BasketItemVM
                {
                    Id=product.Id,
                    Name=product.Name,
                    Price=product.Price,
                    Image = product.ProductImages.FirstOrDefault().ImageUrl,
                    Count=cookie.Count
                };

                basketItems.Add(itemVM);

            }






           

            return View(basketItems);
        }
    }
}
