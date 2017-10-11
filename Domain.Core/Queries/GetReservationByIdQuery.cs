using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class GetReservationByIdQuery : IQuery<Reservation>
    {
        public int Id { get; set; }
    }
}