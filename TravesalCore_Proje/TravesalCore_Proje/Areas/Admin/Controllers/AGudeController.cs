using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AGude")]
	public class AGudeController : Controller
	{
		private readonly IGuideService _guideService;

		public AGudeController(IGuideService guideService)
		{
			_guideService = guideService;
		}
		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			var values = _guideService.TGetList();
			return View(values);
		}
        [Route("AddGuide")]
        [HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
			GudeValidator validationRules = new GudeValidator();
			ValidationResult result = validationRules.Validate(guide);
			if(result.IsValid)
			{
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}
        }
        [Route("EditGuide")]
        [HttpGet]
		public IActionResult EditGuide(int id)
		{
			var values = _guideService.GetByID(id);
			return View(values);
		}
        [Route("EditGuide")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

		[Route("ChamgeToTrue/{id}")]
		public IActionResult ChamgeToTrue(int id)
		{
			_guideService.TChamgeToTrueByGuide(id);
            return RedirectToAction("Index", "AGude", new { area = "Admin" });
        }
        [Route("ChamgeToFalse/{id}")]
        public IActionResult ChamgeToFalse(int id)
        {
            _guideService.TChamgeToFalseByGuide(id);
            return RedirectToAction("Index");
        }
    }
}
