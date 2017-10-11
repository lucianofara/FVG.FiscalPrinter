namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public interface IQueryProcessor
    {
        TResult Handler<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}