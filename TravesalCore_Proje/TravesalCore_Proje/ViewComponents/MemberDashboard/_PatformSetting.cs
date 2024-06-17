using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.MemberDashboard
{
    public class _PatformSetting : ViewComponent
    {
     
        public IViewComponentResult Invoke()
        {
        
            return View();
        }
    }
}
