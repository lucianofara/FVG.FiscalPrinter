using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Presentation.API.Helpers
{
    public interface IPrintProcessor
    {
        TResponse PrintAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest where TResponse : IResponse;
    }
}