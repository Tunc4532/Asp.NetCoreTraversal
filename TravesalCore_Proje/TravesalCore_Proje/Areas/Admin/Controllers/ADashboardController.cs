using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ADashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
