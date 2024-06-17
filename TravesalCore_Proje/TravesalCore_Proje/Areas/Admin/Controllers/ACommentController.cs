using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ACommentController : Controller
    {
        private readonly ICommentService _commentService;

        public ACommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.GetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
