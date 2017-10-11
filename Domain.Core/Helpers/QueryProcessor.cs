using Autofac;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Domain.Core.Helpers
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly ILifetimeScope container;

        public QueryProcessor(ILifetimeScope container)
        {
            this.container = container;
        }

        public TResult Handler<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = container.Resolve<IQueryHandler<TQuery, TResult>>();
            return handler.Handler(query);
        }
    }
}