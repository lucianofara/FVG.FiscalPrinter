using FVG.FiscalPrinter.Domain.Core.Commands;
using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Queries
{
    public class FindReservationQueryHandler : _BaseHandler, IQueryHandler<FindReservationQuery, IEnumerable<Reservation>>
    {
        public FindReservationQueryHandler(IDataContext db) : base(db)
        {
        }

        public IEnumerable<Reservation> Handler(FindReservationQuery query)
        {
            return _db.Reservation
                .AsNoTracking()
                .Where(x => x.PrinterName == query.PrinterName)
                .Where(x => x.Channel == query.Channel)
                .Where(x => x.ExpirationDate == null || x.ExpirationDate > DateTime.Now).ToList();
        }
    }
}