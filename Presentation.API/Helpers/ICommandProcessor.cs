using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Presentation.API.Helpers
{
    public interface ICommandProcessor
    {
        void Handler<TCommand>(TCommand command) where TCommand : ICommand;
    }
}