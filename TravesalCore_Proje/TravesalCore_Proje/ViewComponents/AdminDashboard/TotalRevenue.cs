using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.AdminDashboard
{
    public class TotalRevenue : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
