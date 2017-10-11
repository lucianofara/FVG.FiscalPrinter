using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;
using System.Collections.Generic;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class FindReservationQuery : IQuery<IEnumerable<Reservation>>
    {
        public FindReservationQuery(string printerName, string channel)
        {
            this.Channel = channel;
            this.PrinterName = printerName;
        }

        public string PrinterName { get; set; }
        public string Channel { get; set; }
    }
}