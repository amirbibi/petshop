using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace PetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return View(registerModel);

            // Check if user already exists
            var existingUser = await _userManager.FindByNameAsync(registerModel.Username!);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username already in use.");
                return View(registerModel);
            }

            var existingRole = await _roleManager.FindByNameAsync(registerModel.Role!);
            if (existingRole is null)
            {
                IdentityRole usersRole = new()
                {
                    Name = registerModel.Role
                };
                await _roleManager.CreateAsync(usersRole);
            }

            IdentityUser user = new()
            {
                UserName = registerModel.Username,
            };

            var createUserResult = await _userManager.CreateAsync(user, registerModel.Password!);
            var createRoleResult = await _userManager.AddToRoleAsync(user, registerModel.Role!);

            if (createUserResult.Succeeded && createRoleResult.Succeeded)
                return RedirectToAction("Login");

            return View(registerModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
