using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
