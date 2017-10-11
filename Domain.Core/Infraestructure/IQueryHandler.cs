namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handler(TQuery query);
    }
}