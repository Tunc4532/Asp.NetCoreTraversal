using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface InReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWİthReservationByWaitAprroval(int id);
        List<Reservation> GetListWİthReservationByAccepted(int id);
        List<Reservation> GetListWİthReservationByPrevious(int id);


    }
}
