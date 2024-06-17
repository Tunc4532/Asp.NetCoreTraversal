using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager _guideManager = new GuideManager(new EfGuideDal());

        public IActionResult Index()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
    }
}
