using FVG.FiscalPrinter.Domain.Core.Commands;
using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class FindFiscalPrinterQueryHandler : _BaseHandler, IQueryHandler<FindFiscalPrinterQuery, IEnumerable<Entities.FiscalPrinter>>
    {
        public FindFiscalPrinterQueryHandler(IDataContext db) : base(db)
        {
        }

        public IEnumerable<Entities.FiscalPrinter> Handler(FindFiscalPrinterQuery query)
        {
            return _db.FiscalPrinter
                .AsNoTracking()
                .Where(x => x.PrinterName == query.PrinterName)
                .Where(x => x.Channel == query.Channel)
                .Where(x => x.Active).ToList();
        }
    }
}