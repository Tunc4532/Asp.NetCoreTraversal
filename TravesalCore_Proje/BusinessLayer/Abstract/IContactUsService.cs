using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService : IGenericService<ContactUs>
    {
        object TGetList();
        List<ContactUs> TGetListContacUsByTrue();
        List<ContactUs> TGetListContacUsByfalse();

        void TContactUsStatusChangeToFalse(int id);

    }
}
