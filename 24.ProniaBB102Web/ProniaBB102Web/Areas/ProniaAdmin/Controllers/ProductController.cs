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


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
           
            Product product=await _context.Products.Where(p => p.Id == id).Include(p=>p.ProductImages).Include(p=>p.ProductTags).FirstOrDefaultAsync();
            if (product is null) return NotFound();
            UpdateProductVM productVM = new UpdateProductVM
            {
                Name = product.Name,
                Description = product.Description,
                SKU = product.SKU,
                Price = product.Price,
                CategoryId = product.CategoryId,
                TagIds = product.ProductTags.Select(pt=>pt.TagId).ToList(),
                

            };
            productVM = MapImages(productVM, product);

           
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            return View(productVM);

            //foreach (ProductTag pTag in product.ProductTags)
            //{
            //    productVM.TagIds.Add(pTag.TagId);
            //}

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateProductVM productVM)
        {
            if (id == null || id <= 0) return BadRequest();
            Product existed = await _context.Products.Where(p => p.Id == id).Include(p => p.ProductTags).Include(p=>p.ProductImages).FirstOrDefaultAsync();
            if (existed is null) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                productVM = MapImages(productVM, existed);
                return View(productVM);
            }

            if (!await _context.Categories.AnyAsync(c=>c.Id==productVM.CategoryId))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("CategoryId", "Bele bir category yoxdur");
                productVM = MapImages(productVM, existed);
                return View(productVM);
            }

            existed.Price = productVM.Price;
            existed.Description = productVM.Description;
            existed.Name = productVM.Name;
            existed.SKU = productVM.SKU;
            existed.CategoryId = productVM.CategoryId;

            if (productVM.TagIds is null)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("TagIds", "En azi 1 tag secin");
                productVM = MapImages(productVM, existed);
                return View(productVM);
            }

            if (productVM.MainPhoto != null)
            {
                if (!productVM.MainPhoto.CheckFileType("image/"))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("MainPhoto", "Sheklin novu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                if (!productVM.MainPhoto.CheckFileSize(200))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("MainPhoto", "Sheklin olcusu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                var mainImage = existed.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true);
                mainImage.ImageUrl.DeleteFile(_env.WebRootPath, "assets/images/website-images");
                existed.ProductImages.Remove(mainImage);
                ProductImage productImage = new ProductImage
                {
                    ProductId = existed.Id,
                    ImageUrl = await productVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    IsPrimary = true

                };
                existed.ProductImages.Add(productImage);
            }
            if (productVM.HoverPhoto != null)
            {
                if (!productVM.HoverPhoto.CheckFileType("image/"))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("HoverPhoto", "Sheklin novu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                if (!productVM.HoverPhoto.CheckFileSize(200))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("HoverPhoto", "Sheklin olcusu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                var hoverImage = existed.ProductImages.FirstOrDefault(pi => pi.IsPrimary == false);
                hoverImage.ImageUrl.DeleteFile(_env.WebRootPath, "assets/images/website-images");
                existed.ProductImages.Remove(hoverImage);
                ProductImage productImage = new ProductImage
                {
                    ProductId = existed.Id,
                    ImageUrl = await productVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    IsPrimary = false

                };
                existed.ProductImages.Add(productImage);
            }

            List<ProductImage> removeImageList= existed.ProductImages.Where(pi=>!productVM.ImagesIds.Contains(pi.Id)&&pi.IsPrimary==null).ToList();
            foreach (ProductImage pImage in removeImageList)
            {
                pImage.ImageUrl.DeleteFile(_env.WebRootPath,"assets/images/website-images");
                existed.ProductImages.Remove(pImage);
            }
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
                    ProductId=existed.Id
                };

                existed.ProductImages.Add(addImage);
            }



            List<int> createList = productVM.TagIds.Where(t => !existed.ProductTags.Exists(pt => pt.TagId == t)).ToList();
            foreach (int tagId in createList)
            {
                bool tagResult = await _context.Tags.AnyAsync(pt=>pt.Id==tagId);
                if (!tagResult)
                {

                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("TagIds", "Bele tag movcud deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                ProductTag productTag = new ProductTag
                {
                    ProductId = existed.Id,
                    TagId = tagId
                };
                existed.ProductTags.Add(productTag);
            }

            List<ProductTag> removeList = existed.ProductTags.Where(pt => !productVM.TagIds.Contains(pt.TagId)).ToList();


            _context.ProductTags.RemoveRange(removeList);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));   
        }


        public UpdateProductVM MapImages(UpdateProductVM productVM,Product product)
        {
            productVM.ProductImageVMs = new List<ProductImageVM>();
            foreach (ProductImage image in product.ProductImages)
            {
                ProductImageVM imageVM = new ProductImageVM
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    IsPrimary = image.IsPrimary
                };
                productVM.ProductImageVMs.Add(imageVM);
            }
            return productVM;
        }
        //public async void ViewBags()
        //{
        //    ViewBag.Categories = await _context.Categories.ToListAsync();
        //    ViewBag.Tags = await _context.Tags.ToListAsync();
        //}

    }
}
