using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;

namespace ProniaBB102Web.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;

        public SlideController(AppDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create(Slide slide)
        {
            if (slide.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil hissesi bosh ola bilmez");
                return View();
            }

            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin tipi uygun deyil");
                return View();
            }
            if (slide.Photo.Length  > 200*1024)
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin hecmi 200 kb-den boyuk olmamalidir");
                return View();
            }

            FileStream file = new FileStream(@"C:\Users\sabir\Desktop\BB102 git\24.ProniaBB102Web\ProniaBB102Web\wwwroot\assets\images\website-images\" + slide.Photo.FileName,FileMode.Create);
            await slide.Photo.CopyToAsync(file);


            slide.Image = slide.Photo.FileName;

            await _context.Slides.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");










        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
