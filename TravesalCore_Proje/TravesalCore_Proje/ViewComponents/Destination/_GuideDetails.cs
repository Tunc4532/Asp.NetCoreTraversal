using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.Destination
{
    public class _GuideDetails : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _guideService.GetByID(1);
            return View(values);
        }

    }
}
