using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravesalCore_Proje.Models;

namespace TravesalCore_Proje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ========================================================================================= //

        [HttpGet]
        public IActionResult SıgnUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SıgnUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
				Email = p.Mail,
				UserName = p.UserName
            };
            if(p.Password == p.ConfrimPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SıgnIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        // ========================================================================================= //

        [HttpGet]
        public IActionResult SıgnIn()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> SıgnIn(UserSıgnInUserModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile" , new { area= "Member" });
                }
                else
                {
                    return RedirectToAction("SıgnIn", "Login");
                }
            }

            return View();
        }
    }
}
