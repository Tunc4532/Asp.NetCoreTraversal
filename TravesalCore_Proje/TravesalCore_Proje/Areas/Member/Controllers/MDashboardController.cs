using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Member.Controllers
{
    [Area("Member")]
    public class MDashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MDashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.namesurname = values.Name + " " + values.Surname;
            ViewBag.userimage = values.ImageUrl;
            return View();
        }
    }
}
