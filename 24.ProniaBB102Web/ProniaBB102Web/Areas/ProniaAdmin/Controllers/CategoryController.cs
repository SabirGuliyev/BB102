using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Utilities.Enums;

namespace ProniaBB102Web.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    [AutoValidateAntiforgeryToken]
    //[Authorize(Roles =$"Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin,Moderator")]
        public async Task<IActionResult> Index()
        {

            List<Category> categories=await _context.Categories.Include(c=>c.Products).ToListAsync();



            return View(categories);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            //return View();
            return RedirectToAction("Index", "Home", null);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Office   --   oFFice 
            //office    --  office
            bool result= _context.Categories.Any(c=>c.Name.Trim().ToLower()==category.Name.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda categoriya artiq movcuddur");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

           return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed=await _context.Categories.FirstOrDefaultAsync(c=>c.Id==id);

            if (existed == null) return NotFound();

            return View(existed);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (existed == null) return NotFound();


            if (existed.Name == category.Name)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(existed);
            }

            bool result = _context.Categories.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower()&&c.Id!=id);

            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda categoriya artiq movcuddur");
                return View(existed);
            }

            existed.Name=category.Name;

          
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete( int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed = await _context.Categories.FirstOrDefaultAsync(c=>c.Id==id);

            if (existed == null) return NotFound();


            _context.Categories.Remove(existed);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
           
         
             
        }
    }
}
