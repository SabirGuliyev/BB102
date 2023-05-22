using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaBB102Web.Models;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM newUser)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                UserName = newUser.Username
            };

            IdentityResult result=await _userManager.CreateAsync(user,newUser.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }





            await _signInManager.SignInAsync(user,false);

            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        { 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
