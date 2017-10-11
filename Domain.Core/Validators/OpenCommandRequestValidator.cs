using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.ServiceContract;
using System;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Validators
{
    public class OpenCommandRequestValidator : IValidator<OpenCommandRequest>
    {
        public void Validate(OpenCommandRequest request)
        {
            if (request.Document.Header == null)
                throw new ArgumentNullException(nameof(request.Document.Header));
            if (String.IsNullOrEmpty(request.Document.Header.PrinterName))
                throw new ArgumentNullException(nameof(request.Document.Header.PrinterName));
            if (String.IsNullOrEmpty(request.Document.Header.Register))
                throw new ArgumentNullException(nameof(request.Document.Header.Register));
            if (String.IsNullOrEmpty(request.Document.Header.Channel))
                throw new ArgumentNullException(nameof(request.Document.Header.Channel));

            //commands
            if (request.Document.Commands == null)
                throw new ArgumentNullException(nameof(request.Document.Commands));
            if (request.Document.Commands.Count() == 0)
                throw new ArgumentNullException(nameof(request.Document.Commands));
        }
    }
}