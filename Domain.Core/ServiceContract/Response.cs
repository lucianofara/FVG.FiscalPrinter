using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Domain.Core.ServiceManager
{
    public class Response : IResponse
    {
        public Response()
        {
            Success = 0;
            Error = string.Empty;
            Reservation = string.Empty;
            Cancelado = string.Empty;
        }

        public int Success { get; set; }
        public string Error { get; set; }
        public Comprobante Comprobante { get; set; }
        public string Reservation { get; set; }
        public string Cancelado { get; set; }
    }

    public class Success : Response
    {
        public Success() : base()
        {
            Success = 1;
        }

        public Success(string comprobante) : base()
        {
            Success = 1;
            Comprobante = new Comprobante()
            {
                NroComprobante = comprobante
            };
        }

        public Success(string reservation, string comprobante) : base()
        {
            Success = 1;
            Comprobante = new Comprobante()
            {
                NroComprobante = comprobante
            };
            Reservation = reservation;
        }

        public Success(string comprobante, string reservation, string cancelado) : base()
        {
            Success = 1;
            Comprobante = new Comprobante()
            {
                NroComprobante = comprobante
            };
            Reservation = reservation;
            Cancelado = cancelado;
        }
    }

    public class Fail : Response
    {
        public Fail(string error) : base()
        {
            Error = error;
        }

        public Fail(string error, string cancelado) : base()
        {
            Error = error;
            Cancelado = cancelado;
        }
    }

    public class Comprobante
    {
        public string Tipo { get; set; }
        public string NroComprobante { get; set; }
        public double Importe { get; set; }
    }
}