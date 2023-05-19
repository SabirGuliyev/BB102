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

        public LayoutService(AppDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public async  Task<Dictionary<string,string>> GetSettings()
        {
            var settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

             return settings;
        }
        public async Task<List<BasketItemVM>> GetBasket()
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

            List<BasketItemVM> basketItems = new List<BasketItemVM>();

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


            return basketItems;

        }
    }
}
