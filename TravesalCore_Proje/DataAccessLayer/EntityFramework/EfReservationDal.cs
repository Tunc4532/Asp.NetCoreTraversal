using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepostory<Reservation>, InReservationDal
    {
        public List<Reservation> GetListWİthReservationByAccepted(int id)
        {
            using (var contex = new Context())
            {
                return contex.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWİthReservationByPrevious(int id)
        {
            using (var contex = new Context())
            {
                return contex.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWİthReservationByWaitAprroval(int id)
        {
            using (var contex = new Context())
            {
                return contex.Reservations.Include(x => x.Destination).Where(x => x.Status =="Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }
    }
}
