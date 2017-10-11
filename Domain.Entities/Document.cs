using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FVG.FiscalPrinter.Domain.Entities
{
    public class Document : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string NroComprobante { get; set; }
        public double Importe { get; set; }
        public DateTime Date { get; set; }
        public string Channel { get; set; }
        public string Register { get; set; }
        public string PrinterName { get; set; }

    }
}
