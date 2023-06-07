using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor http,UserManager<AppUser> userManager )
        {
            _context = context;
            _http = http;
            _userManager = userManager;
        }

        public async  Task<Dictionary<string,string>> GetSettings()
        {
            var settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

             return settings;
        }
        public async Task<List<BasketItemVM>> GetBasket()
        {
            List<BasketItemVM> basketItems;
            if (_http.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(_http.HttpContext.User.Identity.Name);
                if (user is null) throw new Exception("nese o deyile");
                basketItems = new List<BasketItemVM>();
                List<BasketItem> userItems = await _context.BasketItems
                    .Where(b => b.AppUserId == user.Id && b.OrderId == null)
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

                string json = _http.HttpContext.Request.Cookies["Basket"];

                if (!String.IsNullOrEmpty(json))
                {
                    basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(json);
                }
                else
                {
                    basket = new List<BasketCookiesItemVM>();
                }

                basketItems = new List<BasketItemVM>();

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


            return basketItems;

        }
    }
}
