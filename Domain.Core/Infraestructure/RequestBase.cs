using FVG.FiscalPrinter.Domain.Entities;

namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public class RequestBase
    {
        public string Url { get; set; }
        public PrintDocument Document { get; set; }
    }
}