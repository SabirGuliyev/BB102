using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;

namespace ProniaBB102Web.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int key=1)
        {
            List<Product> products;

            switch (key)
            {
                case 1:
                    products = await _context.Products.OrderBy(p => p.Name).Take(8).Include(p => p.ProductImages).ToListAsync();
                    break;
                case 2:
                    products = await _context.Products.OrderBy(p=>p.Price).Take(8).Include(p => p.ProductImages).ToListAsync();
                    break;
                default:
                    products = await _context.Products.Include(p => p.ProductImages).ToListAsync();
                    break;
            }
            

            //return View(await Task.FromResult(products));
            return View(products);
        }
    }
}
