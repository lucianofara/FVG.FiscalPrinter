using FVG.FiscalPrinter.Domain.Core.Commands;
using FVG.FiscalPrinter.Domain.Core.Helpers;
using FVG.FiscalPrinter.Domain.Core.Queries;
using FVG.FiscalPrinter.Domain.Core.ServiceManager;
using FVG.FiscalPrinter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Infraestructure
{
    public class _BasePrintHandler
    {
        public ICommandProcessor _commandProcessor;
        public IQueryProcessor _queryProcessor;
        public IServiceManager _serviceManager;

        public _BasePrintHandler(ICommandProcessor commandProcessor, IServiceManager serviceManager, IQueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _serviceManager = serviceManager;
            _queryProcessor = queryProcessor;
        }

        public bool GetPrinterConfiguration(RequestBase request)
        {
            FindFiscalPrinterQuery findFiscalPrinter = new FindFiscalPrinterQuery(request.Document.Header.PrinterName, request.Document.Header.Channel);
            var printers = _queryProcessor.Handler<FindFiscalPrinterQuery, IEnumerable<Entities.FiscalPrinter>>(findFiscalPrinter);
            if (printers.Count() != 1)
                return false;
            else
            {
                var printer = printers.FirstOrDefault();
                request.Document.Header.Ip = printer.Ip;
                request.Document.Header.Port = int.Parse(printer.Port);
                request.Document.Header.PrinterModel = printer.Model;
            }
            return true;
        }

        public IEnumerable<Reservation> GetReservation(RequestBase request)
        {
            FindReservationQuery query = new FindReservationQuery(request.Document.Header.PrinterName, request.Document.Header.Channel);
            return _queryProcessor.Handler<FindReservationQuery, IEnumerable<Reservation>>(query);
        }

        public int CreateReservation(RequestBase request)
        {
            CreateReservationCommand command = new CreateReservationCommand(new Reservation()
            {
                Channel = request.Document.Header.Channel,
                Date = DateTime.Now,
                PrinterName = request.Document.Header.PrinterName,
                Register = request.Document.Header.Register
            });
            _commandProcessor.Handler(command);
            return command.Reservation.Id;
        }

        public void ExpirateReservation(int reservationId, bool extendTime = false)
        {
            _commandProcessor.Handler(new UpdateReservationCommand(reservationId)
            {
                ExpirationDate = (extendTime) ? DateTime.Now.AddSeconds(30) : (DateTime?)null
            });
        }

        public void CreateDocument(RequestBase request, Response response)
        {
            _commandProcessor.Handler(new CreateDocumentCommand(
                   new Document()
                   {
                       Channel = request.Document.Header.Channel,
                       Date = DateTime.Now,
                       Importe = response.Comprobante.Importe,
                       NroComprobante = response.Comprobante.NroComprobante,
                       PrinterName = request.Document.Header.PrinterName,
                       Register = request.Document.Header.Register,
                       Tipo = response.Comprobante.Tipo
                   }));
        }
    }
}