using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class CreateReservationCommand : ICommand
    {
        public CreateReservationCommand(Reservation reservation)
        {
            Reservation = reservation;
        }

        public Reservation Reservation { get; set; }
    }
}