using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using System;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class UpdateReservationCommand : ICommand
    {
        public UpdateReservationCommand(int id)
        {
            this.Id = id;
            this.ExpirationDate = null;
        }

        public DateTime? ExpirationDate { get; set; }
        public int Id { get; set; }
    }
}