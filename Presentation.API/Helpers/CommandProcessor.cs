using Autofac;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Presentation.API.Helpers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ILifetimeScope container;

        public CommandProcessor(ILifetimeScope container)
        {
            this.container = container;
        }

        public void Handler<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = container.Resolve<ICommandHandler<TCommand>>();
            handler.Handler(command);
        }
    }
}