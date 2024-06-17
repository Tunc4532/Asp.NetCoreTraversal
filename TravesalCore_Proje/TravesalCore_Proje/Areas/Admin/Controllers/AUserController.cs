using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AUserController : Controller
    {
        private readonly IAppUserService  _userService;

        private readonly IReservationService _reservationService;

        public AUserController(IAppUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var value = _userService.GetByID(id);
            _userService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _userService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _userService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult AddUser(int id )
        {
            var values = _userService.TGetList();
            return View(values);
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWİthReservationByAccepted(id);
            return View(values);
        }
    }
}
