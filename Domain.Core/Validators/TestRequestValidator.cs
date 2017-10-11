using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.ServiceContract;
using System;

namespace FVG.FiscalPrinter.Domain.Core.Validators
{
    public class TestRequestValidator : IValidator<TestRequest>
    {
        public void Validate(TestRequest request)
        {
            if (request.Document.Header == null)
                throw new ArgumentNullException(nameof(request.Document.Header));
            if (String.IsNullOrEmpty(request.Document.Header.PrinterName))
                throw new ArgumentNullException(nameof(request.Document.Header.PrinterName));
            if (String.IsNullOrEmpty(request.Document.Header.Register))
                throw new ArgumentNullException(nameof(request.Document.Header.Register));
            if (String.IsNullOrEmpty(request.Document.Header.Channel))
                throw new ArgumentNullException(nameof(request.Document.Header.Channel));
        }
    }
}