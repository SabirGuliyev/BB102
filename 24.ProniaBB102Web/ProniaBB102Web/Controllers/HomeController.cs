using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Interfaces;
using ProniaBB102Web.Models;
using ProniaBB102Web.ViewModels;
using Stripe;

namespace ProniaBB102Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public HomeController(AppDbContext context,UserManager<AppUser> userManager,IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            
            //return Content(HttpContext.Session.GetString("Name")+"  " + Request.Cookies["Name"]);
            
            //Response.Cookies.Append("Name", "Yusif",new CookieOptions
            //{
            //    MaxAge=TimeSpan.FromSeconds(50)
            //});


            //HttpContext.Session.SetString("Name", "Azade");
            HomeVM homeVM = new HomeVM
            {
                Products=await _context.Products.Include(p=>p.ProductImages).ToListAsync(),
            };
            return View(homeVM);
        }
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            ViewBag.BasketItems = await _context.BasketItems.Where(b => b.AppUserId == user.Id&&b.OrderId==null).ToListAsync();
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderVM orderVM,string stripeEmail,string stripeToken)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();
            List<BasketItem> items= await _context.BasketItems.Where(b => b.AppUserId == user.Id && b.OrderId == null).Include(b=>b.Product).ToListAsync();
            if (!ModelState.IsValid)
            {
                ViewBag.BasketItems = items;
                return View();
            }
            decimal total=0;
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].Count * items[i].Price;
            }
            Order order = new Order
            {
                AppUserId = user.Id,
                Status = null,
                BasketItems = items,
                PurchaseAt=DateTime.Now,
                TotalPrice=total,
                Address=orderVM.Address
                
            };

            //Stripe
            var optionCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = user.Name + " " + user.Surname,
                Phone = "+994 50 66"
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionCust);

            total = total * 100;

            var optionsCharge = new ChargeCreateOptions
            {

                Amount = (long)total,
                Currency = "USD",
                Description = "Product Selling amount",
                Source = stripeToken,
                ReceiptEmail = stripeEmail


            };
            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);

            if (charge.Status != "succeeded")
            {
                ViewBag.BasketItems = items;
                ModelState.AddModelError("Address", "Odenishde problem var");
                return View();
            }


            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            string body = @"
                              <table>
                                  < thead>
                                      <tr>
                                          <th>Product</th>
                                          <th>Count</th>
                                          <th>Price</th>
                                      </tr>
                                  </thead>
                                  <tbody>";

            foreach (var item in order.BasketItems)
            {
                body += @$" <tr>
                               <td>{item.Product.Name}</td>
                               <td>{item.Count}</td>
                               <td>{item.Price}</td>
                           </tr>";
            }
            body += @"</tbody>
                              </table>";

            _emailService.SendEmail(user.Email, "Order Placement", body,true);


            return RedirectToAction(nameof(Index));
        }


        public IActionResult ErrorPage(string errorMessage="error")
        {
            return View(model:errorMessage);
        }
    }
}
