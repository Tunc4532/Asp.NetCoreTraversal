using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        //private readonly UserManager<AppUser> _userManager;

        //public DestinationController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        { 
            ViewBag.i = id;
            //var resultr = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.nameUser = resultr.Id;
            var values = destinationManager.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
