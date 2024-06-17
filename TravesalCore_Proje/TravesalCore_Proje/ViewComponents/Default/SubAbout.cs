using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.Default
{

    public class SubAbout : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());

        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetList();

            return View(values);
        }

    }
}
