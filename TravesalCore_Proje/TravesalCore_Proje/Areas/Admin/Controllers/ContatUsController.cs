using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ContatUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContatUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {

            var values = _contactUsService.TGetListContacUsByTrue();
            return View(values);
        }
    }
}
