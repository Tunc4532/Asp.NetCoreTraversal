using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Mesaj Detayları";
            ViewBag.v3 = "Yeni Mesaj";
            return View();
        }
    }
}
