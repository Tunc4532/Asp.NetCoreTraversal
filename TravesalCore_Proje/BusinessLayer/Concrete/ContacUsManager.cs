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
    public class ContacUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContacUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public ContactUs GetByID(int id)
        {
            return _contactUsDal.GetByID(id);
        }

        public void TAdd(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ContactUs t)
        {
            _contactUsDal.Delete(t);
        }

        public List<ContactUs> TGetList(ContactUs t)
        {
            return _contactUsDal.GetList();
        }

        public object TGetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListContacUsByfalse()
        {
            return _contactUsDal.GetListContacUsByfalse();
        }

        public List<ContactUs> TGetListContacUsByTrue()
        {
            return _contactUsDal.GetListContacUsByTrue();
        }

        public void TUpdate(ContactUs t)
        {
            _contactUsDal.Update(t);
        }
    }
}
