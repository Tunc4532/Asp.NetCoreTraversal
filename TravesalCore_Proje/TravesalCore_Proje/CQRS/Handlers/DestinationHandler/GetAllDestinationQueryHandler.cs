using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TravesalCore_Proje.CQRS.Results.DestinationResults;

namespace TravesalCore_Proje.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.DenID,
                daynight = x.DayNight,
                price = x.Price,

            }).AsNoTracking().ToList();
            return values;
        }



    }
}
