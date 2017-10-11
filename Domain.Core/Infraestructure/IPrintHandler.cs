namespace FVG.FiscalPrinter.Domain.Core.Print
{
    public interface IPrintHandler<TRequest, TResponse>
    {
        TResponse Print(TRequest request);
    }
}