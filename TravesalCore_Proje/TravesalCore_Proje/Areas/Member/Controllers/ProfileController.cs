using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using TravesalCore_Proje.Areas.Member.Models;

namespace TravesalCore_Proje.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            ViewBag.v1 = "Profil";
            ViewBag.v2 = "Profil Bilgileri";
            ViewBag.v3 = "Düzenleme";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.Phonenumber = values.PhoneNumber;
            userEditViewModel.email = values.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/Userİmages/" + imagename;
                var stream = new FileStream(savelocation , FileMode.Create);
                await p.image.CopyToAsync(stream);
                values.ImageUrl = imagename;

            }
            values.Name = p.name;
            values.Surname = p.surname;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            var result = await _userManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("SıgnIn", "Login");
            }

            return View();
        }
    }
}
