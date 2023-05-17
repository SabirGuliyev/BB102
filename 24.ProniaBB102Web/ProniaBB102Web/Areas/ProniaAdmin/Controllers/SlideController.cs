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
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;

        public SlideController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _context.Slides.ToListAsync();


            return View(slides);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSlideVM slideVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //if (slide.Photo == null)
            //{
            //    ModelState.AddModelError("Photo", "Shekil hissesi bosh ola bilmez");
            //    return View();
            //}

            if (!slideVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin tipi uygun deyil");
                return View();
            }
            if (!slideVM.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin hecmi 200 kb-den boyuk olmamalidir");
                return View();
            }

            Slide slide=new Slide
            {
                
                Title = slideVM.Title,
                SubTitle = slideVM.SubTitle,
                Description = slideVM.Description,
                Order = slideVM.Order,
            };
            slide.Image =await slideVM.Photo.CreateFileAsync(_env.WebRootPath, @"assets/images/website-images");

            await _context.Slides.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Slide slide = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (slide == null) return NotFound();
           
            UpdateSlideVM slideVM= new UpdateSlideVM
            {
                Title = slide.Title,
                SubTitle= slide.SubTitle,
                Description= slide.Description,
                Order= slide.Order,
                Image=slide.Image
            };

            return View(slideVM);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, UpdateSlideVM slideVM)
        {

            if (id == null || id < 1) return BadRequest();

            Slide existed = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null) return NotFound();



            if (slideVM.Photo != null)
            {
                if (!slideVM.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File tipi uygun deyil");
                    return View();
                }
                if (!slideVM.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "File hecmi 200 kb den cox olmamalidir");
                    return View();
                }
                existed.Image.DeleteFile(_env.WebRootPath, @"assets/images/website-images");
                existed.Image = await slideVM.Photo.CreateFileAsync(_env.WebRootPath, @"assets/images/website-images");
            }

            existed.Order = slideVM.Order;
            existed.Title = slideVM.Title;
            existed.SubTitle = slideVM.SubTitle;
            existed.Description = slideVM.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Slide slide = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (slide == null) return NotFound();

            slide.Image.DeleteFile(_env.WebRootPath, @"assets/images/website-images");

            _context.Slides.Remove(slide);
             await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(Index));
        }
    }
}
