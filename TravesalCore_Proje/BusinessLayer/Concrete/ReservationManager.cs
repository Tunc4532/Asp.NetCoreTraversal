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
    public class ReservationManager : IReservationService
    {
        InReservationDal _reservationDal;

        public ReservationManager(InReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation GetByID(int id)
        {
           return _reservationDal.GetByID(id);
        }

        // ===================================================================== //
        //Şarta göre listeleme metotları
        public List<Reservation> GetListWİthReservationByAccepted(int id)
        {
            return _reservationDal.GetListWİthReservationByAccepted(id);
        }

        public List<Reservation> GetListWİthReservationByPrevious(int id)
        {
            return _reservationDal.GetListWİthReservationByPrevious(id);
        }

        public List<Reservation> GetListWİthReservationByWaitAprroval(int id)
        {
            return _reservationDal.GetListWİthReservationByWaitAprroval(id);
        }

        // ===================================================================== //

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public List<Reservation> TGetList(Reservation t)
        {
            return _reservationDal.GetList();
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
