using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
