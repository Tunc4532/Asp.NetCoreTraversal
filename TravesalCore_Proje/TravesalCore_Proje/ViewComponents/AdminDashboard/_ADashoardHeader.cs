﻿using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.ViewComponents.AdminDashboard
{
    public class _ADashoardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}