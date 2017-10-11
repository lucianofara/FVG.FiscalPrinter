namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handler(TCommand command);
    }
}