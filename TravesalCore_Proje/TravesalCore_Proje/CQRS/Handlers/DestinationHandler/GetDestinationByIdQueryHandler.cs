using DataAccessLayer.Concrete;
using TravesalCore_Proje.CQRS.Queries.DestinationQueries;
using TravesalCore_Proje.CQRS.Results.DestinationResults;

namespace TravesalCore_Proje.CQRS.Handlers.DestinationHandler
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResults Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResults
            {
               //DayNight = query.

            };


        }
    }
}
