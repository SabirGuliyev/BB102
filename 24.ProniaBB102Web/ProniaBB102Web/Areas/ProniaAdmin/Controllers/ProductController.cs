using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Utilities.Extensions;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.ProductImages
                .Where(pi => pi.IsPrimary == true))
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .ToListAsync();

            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories=await _context.Categories.ToListAsync();
            ViewBag.Tags=await _context.Tags.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {

         
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                return View();
            }
            bool result = await _context.Categories.AnyAsync(c => c.Id == productVM.CategoryId);
            if (!result)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("CategoryId", "Bu id-li category movcud deyil");
                return View();
            }
            Product product = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                SKU = productVM.SKU,
                CategoryId = productVM.CategoryId,
                ProductTags = new List<ProductTag>(),
                ProductImages=new List<ProductImage>()
            };

            foreach (int tagId in productVM.TagIds)
            {
                bool tagResult = await _context.Tags.AnyAsync(t => t.Id == tagId);
                if (!tagResult)
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("TagIds", $"{tagId} id-li Tag movcud deyil");
                    return View();
                }
                ProductTag productTag = new ProductTag
                {
                    TagId = tagId,
                    Product = product
                };
               product.ProductTags.Add(productTag);
            }


            if (!productVM.MainPhoto.CheckFileType("image/"))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("MainPhoto", "File tipi uygun deyil");
                return View();
            }
            if (!productVM.MainPhoto.CheckFileSize(200))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("MainPhoto", "File olcusu uygun deyil");
                return View();
            }


            if (!productVM.HoverPhoto.CheckFileType("image/"))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("HoverPhoto", "File tipi uygun deyil");
                return View();
            }
            if (!productVM.HoverPhoto.CheckFileSize(200))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("HoverPhoto", "File olcusu uygun deyil");
                return View();
            }

            ProductImage mainImage = new ProductImage
            {
                ImageUrl = await productVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                IsPrimary = true,
                Product=product
            };
            ProductImage hoverImage = new ProductImage
            {
                ImageUrl = await productVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                IsPrimary = false,
                Product = product
            };
            product.ProductImages.Add(mainImage);
            product.ProductImages.Add(hoverImage);

            TempData["PhotoError"] = "";

            foreach (IFormFile photo in productVM.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    TempData["PhotoError"] += $"{photo.FileName} file tipi uygun deyil\t";
                    continue;
                }
                if (!photo.CheckFileSize(200))
                {
                    TempData["PhotoError"] += $"{photo.FileName} file olcusu uygun deyil\t";
                    continue;
                }
                ProductImage addImage = new ProductImage
                {
                    ImageUrl = await photo.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    IsPrimary = null,
                    Product = product
                };

                product.ProductImages.Add(addImage);
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


    }
}
