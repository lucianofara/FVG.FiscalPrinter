using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using System.Collections.Generic;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class FindFiscalPrinterQuery : IQuery<IEnumerable<Entities.FiscalPrinter>>
    {
        public FindFiscalPrinterQuery(string printerName, string channel)
        {
            this.PrinterName = printerName;
            this.Channel = channel;
        }

        public string PrinterName { get; set; }
        public string Channel { get; set; }
    }
}