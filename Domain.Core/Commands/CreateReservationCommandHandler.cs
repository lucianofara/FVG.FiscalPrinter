using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class CreateReservationCommandHandler : _BaseHandler, ICommandHandler<CreateReservationCommand>
    {
        public CreateReservationCommandHandler(IDataContext db) : base(db)
        {
        }

        public void Handler(CreateReservationCommand command)
        {
            _db.Add(command.Reservation).SaveChanges();
        }
    }
}