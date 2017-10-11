using Autofac;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.Print;

namespace FVG.FiscalPrinter.Presentation.API.Helpers
{
    public class PrintProcessor : IPrintProcessor
    {
        private readonly ILifetimeScope container;

        public PrintProcessor(ILifetimeScope container)
        {
            this.container = container;
        }

        public TResponse PrintAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest where TResponse : IResponse
        {
            //en net core hay que llamar por el nombre del key para resolver decorators
            var handler = container.ResolveKeyed<IPrintHandler<TRequest, TResponse>>("validationHandler");
            return handler.Print(request);
        }
    }
}