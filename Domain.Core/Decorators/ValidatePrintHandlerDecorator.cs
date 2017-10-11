using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.Print;
using FVG.FiscalPrinter.Domain.Core.ServiceManager;
using System;

namespace FVG.FiscalPrinter.Domain.Core.Decorators
{
    public sealed class ValidatePrintHandlerDecorator<TRequest> : IPrintHandler<TRequest, Response>
    {
        private readonly IPrintHandler<TRequest, Response> decorated;
        private readonly IValidator<TRequest> validator;

        public ValidatePrintHandlerDecorator(IPrintHandler<TRequest, Response> decorated, IValidator<TRequest> validator)
        {
            this.decorated = decorated;
            this.validator = validator;
        }

        public Response Print(TRequest request)
        {
            try
            {
                this.validator.Validate(request);
            }
            catch (Exception ex)
            {
                return new Fail(ex.Message);
            }

            return this.decorated.Print(request);
        }
    }
}