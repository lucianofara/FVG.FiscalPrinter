using System;
using System.ComponentModel.DataAnnotations;

namespace FVG.FiscalPrinter.Domain.Entities
{
    public class Reservation : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string PrinterName { get; set; }
        public DateTime Date { get; set; }
        public string Channel { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Register { get; set; }
    }
}