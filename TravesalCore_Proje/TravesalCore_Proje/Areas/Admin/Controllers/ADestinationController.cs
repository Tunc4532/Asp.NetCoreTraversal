using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ADestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public ADestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        // ========================================================= //
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        // ========================================================= //

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        // ========================================================= //

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.GetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        // ========================================================= //

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
        // ========================================================= //
    }
}
