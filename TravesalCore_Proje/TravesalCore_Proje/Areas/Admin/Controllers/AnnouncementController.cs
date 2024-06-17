using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TravesalCore_Proje.Areas.Admin.Models;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class AnnouncementController : Controller
    {
        private readonly  IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Announement> announements = (List<Announement>)_announcementService.TGetList();   
            List<AnnouncementViewListModel> model = new List<AnnouncementViewListModel>();
            foreach(var item in announements)
            {
                AnnouncementViewListModel announcementViewListModel = new AnnouncementViewListModel();
                announcementViewListModel.ID = item.AnnounementId;
                announcementViewListModel.Tittle = item.Tittle;
                announcementViewListModel.Content = item.Content;

                model.Add(announcementViewListModel);
            }
            return View(model);
        }

        [HttpGet]
        public  ActionResult AddAnnouncement()  
        { 
            return View();
        }
        [HttpPost]
        public  ActionResult AddAnnouncement(Announement announement)  
        {
            if(ModelState.IsValid)
            {
                _announcementService.TAdd(new Announement()
                {
                   Content = announement.Content,
                   Tittle = announement.Tittle,
                   DateAncmt = announement.DateAncmt,


                });
                return RedirectToAction("Index");
            }
            //_announcementService.TAdd(announement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.GetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id) 
        {
            var values = _announcementService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(Announement annuunement)
        {
            _announcementService.TUpdate(annuunement);
            return RedirectToAction("Index");
        }
    }
}
