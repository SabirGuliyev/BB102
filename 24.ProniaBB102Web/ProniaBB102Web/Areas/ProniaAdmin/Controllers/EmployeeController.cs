using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;

namespace ProniaBB102Web.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    [AutoValidateAntiforgeryToken]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees= await _context.Employees.Include(e=>e.Position).ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> Create()
        {

            ViewBag.Positions = await _context.Positions.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {

            bool result = await _context.Positions.AnyAsync(p => p.Id == employee.PositionId);
            if (!result)
            {
                ModelState.AddModelError("PositionId", "There is no position with this Id");
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View();
            }
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Employee existed = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (existed == null) return NotFound();

            ViewBag.Positions = await _context.Positions.ToListAsync();

            return View(existed);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Employee employee)
        {
           
            if (id == null || id < 1) return BadRequest();

            Employee existed = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (existed == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View(existed);
            }

            if (existed.PositionId!=employee.PositionId)
            {
                bool result = await _context.Positions.AnyAsync(p => p.Id == employee.PositionId);
                if (!result)
                {
                    ModelState.AddModelError("PositionId", "There is no position with this Id");
                    ViewBag.Positions = await _context.Positions.ToListAsync();

                    return View(existed);
                }
                existed.PositionId = employee.PositionId;
            }
          

            existed.Name = employee.Name;
            existed.Surname = employee.Surname;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
