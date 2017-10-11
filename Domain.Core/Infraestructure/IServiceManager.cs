using FVG.FiscalPrinter.Domain.Entities;
using System.Threading.Tasks;

namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public interface IServiceManager
    {
        Task<string> PrintAsync(string url, PrintDocument document);
    }
}