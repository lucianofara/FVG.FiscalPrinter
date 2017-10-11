using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.Queries;
using FVG.FiscalPrinter.Domain.Entities;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class UpdateReservationCommandHandler : _BaseHandler, ICommandHandler<UpdateReservationCommand>
    {
        private readonly IQueryHandler<GetReservationByIdQuery, Reservation> _getReservationByIdQuery;

        public UpdateReservationCommandHandler(IDataContext db,
            IQueryHandler<GetReservationByIdQuery, Reservation> getReservationByIdQuery) : base(db)
        {
            _getReservationByIdQuery = getReservationByIdQuery;
        }

        public void Handler(UpdateReservationCommand command)
        {
            var reservation = _getReservationByIdQuery.Handler(new GetReservationByIdQuery() { Id = command.Id });
            if (command.ExpirationDate == null)
                reservation.ExpirationDate = reservation.Date;
            else
                reservation.ExpirationDate = command.ExpirationDate;

            _db.Update(reservation).SaveChanges();
        }
    }
}