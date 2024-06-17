using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.MemberDashboard
{
    public class _ProfieInformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfieInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name;
            ViewBag.v2 = values.PhoneNumber;
            ViewBag.v3 = values.Email;
            return View();
        }

    }
}
