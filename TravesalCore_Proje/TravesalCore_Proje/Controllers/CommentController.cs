using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Controllers
{
    public class CommentController : Controller
    {

        CommentManager _commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            _commentManager.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
      
    }
}
