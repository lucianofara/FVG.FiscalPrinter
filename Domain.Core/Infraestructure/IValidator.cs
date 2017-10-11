namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public interface IValidator<TRequest>
    {
        void Validate(TRequest request);
    }
}