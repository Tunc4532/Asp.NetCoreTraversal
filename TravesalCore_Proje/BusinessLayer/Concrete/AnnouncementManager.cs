using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnounementDal _announementDal;

        public AnnouncementManager(IAnnounementDal announementDal)
        {
            _announementDal = announementDal;
        }

        public Announement GetByID(int id)
        {
            return _announementDal.GetByID(id);
        }

        public void TAdd(Announement t)
        {
            _announementDal.Insert(t);
        }

        public void TDelete(Announement t)
        {
            _announementDal.Delete(t);
        }

        public List<Announement> TGetList(Announement t)
        {
            return _announementDal.GetList();
        }

        public object TGetList()
        {
            return _announementDal.GetList();
        }

        public void TUpdate(Announement t)
        {
            _announementDal.Update(t);
        }
    }
}
