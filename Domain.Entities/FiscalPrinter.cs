using System.ComponentModel.DataAnnotations;

namespace FVG.FiscalPrinter.Domain.Entities
{
    public class FiscalPrinter : IEntity
    {
        [Key]
        public string PrinterName { get; set; }

        public string Channel { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Model { get; set; }
        public bool Active { get; set; }
    }
}