namespace FVG.FiscalPrinter.Domain.Entities
{
    public class PrintDocument : IEntity
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        public string[] Commands { get; set; }
    }
}