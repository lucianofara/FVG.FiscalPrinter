using FVG.FiscalPrinter.Domain.Core.Commands;
using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class GetReservationByIdQueryHandler : _BaseHandler, IQueryHandler<GetReservationByIdQuery, Reservation>
    {
        public GetReservationByIdQueryHandler(IDataContext db) : base(db)
        {
        }

        public Reservation Handler(GetReservationByIdQuery query)
        {
            return _db.Reservation
                .Where(x => x.Id == query.Id).FirstOrDefault();
        }
    }
}