using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaBB102Web.Interfaces;
using ProniaBB102Web.Models;
using ProniaBB102Web.Utilities.Enums;
using ProniaBB102Web.ViewModels;

namespace ProniaBB102Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager,IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
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

            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new {token,Email=user.Email},Request.Scheme);

            await _emailService.SendEmail(user.Email,"Email Confirmation",confirmationLink);
            //await _signInManager.SignInAsync(user,false);

            return RedirectToAction(nameof(SuccessfullyRegistered),"Account");
        }
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            AppUser user =await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound();
            var result= await _userManager.ConfirmEmailAsync(user,token);

            if (!result.Succeeded)
            {
                return BadRequest();
            }
            await _signInManager.SignInAsync(user,false);
            return View();
        }
        public IActionResult SuccessfullyRegistered()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user,string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser existed = await _userManager.FindByEmailAsync(user.UsernameOrEmail);

            if (existed==null)
            {
                existed=await _userManager.FindByNameAsync(user.UsernameOrEmail);

                if (existed==null)
                {
                    ModelState.AddModelError(String.Empty, "Username, Email or Password is not correct");
                    return View();
                }
            }

           var result= await _signInManager.PasswordSignInAsync(existed, user.Password, user.IsRemember, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(String.Empty, "Login is not enable please try again later");
                return View();
            }
            if (!existed.EmailConfirmed)
            {
                ModelState.AddModelError(String.Empty, "Please confirm your email");
                return View();

            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username, Email or Password is not correct");
                return View();
            }

            if (ReturnUrl!=null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(UserRole)))
            {
                if (!(await _roleManager.RoleExistsAsync(role.ToString())))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return RedirectToAction("Index", "Home");
        }



    }
}
