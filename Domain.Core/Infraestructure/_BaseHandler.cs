using FVG.FiscalPrinter.Domain.Core.Data;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class _BaseHandler
    {
        public IDataContext _db;

        public _BaseHandler(IDataContext db)
        {
            _db = db;
        }
    }
}