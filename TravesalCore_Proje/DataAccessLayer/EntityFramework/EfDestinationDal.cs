using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepostory<Destination>, IDestinationDal
    {
        public List<Destination> GetLast4Destinations()
        {
            using(var contex = new Context())
            {
                var values = contex.Destinations.Take(3).OrderByDescending(x => x.DestinationID).ToList();
                return values;
            }
        }
    }
}
