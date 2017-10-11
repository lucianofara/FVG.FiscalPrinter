using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FVG.FiscalPrinter.Domain.Core.Validators
{

    public class CommandPrintValidator : IValidator<CommandRequest>
    {
        public void Validate(CommandRequest request)
        {
            if (request.Document.Header == null)
                throw new ArgumentNullException(nameof(request.Document.Header));
            if (String.IsNullOrEmpty(request.Document.Header.PrinterName))
                throw new ArgumentNullException(nameof(request.Document.Header.PrinterName));
            if (String.IsNullOrEmpty(request.Document.Header.Register))
                throw new ArgumentNullException(nameof(request.Document.Header.Register));
            if (String.IsNullOrEmpty(request.Document.Header.Channel))
                throw new ArgumentNullException(nameof(request.Document.Header.Channel));
            if (request.Document.Header.Reservation == 0)
                throw new ArgumentNullException(nameof(request.Document.Header.Reservation));

            //commands
            if (request.Document.Commands == null)
                throw new ArgumentNullException(nameof(request.Document.Commands));
            if (request.Document.Commands.Count() == 0)
                throw new ArgumentNullException(nameof(request.Document.Commands));
        }
    }
}
