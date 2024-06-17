using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class MDestinationController : Controller
    {
        DestinationManager rdestinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Rotalar";
            ViewBag.v2 = "Aktif Rotalar";
            ViewBag.v3 = "Detaylar";
            var values = rdestinationManager.TGetList();
            return View(values);
        }
    }
}
