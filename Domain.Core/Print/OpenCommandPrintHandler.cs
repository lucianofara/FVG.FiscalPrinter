using FVG.FiscalPrinter.Domain.Core.Commands;
using FVG.FiscalPrinter.Domain.Core.Helpers;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.Queries;
using FVG.FiscalPrinter.Domain.Core.ServiceContract;
using FVG.FiscalPrinter.Domain.Core.ServiceManager;
using FVG.FiscalPrinter.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVG.FiscalPrinter.Domain.Core.Print
{
    public class OpenCommandPrintHandler : _BasePrintHandler, IPrintHandler<OpenCommandRequest, Response>
    {
        
        public OpenCommandPrintHandler(ICommandProcessor commandProcessor, IServiceManager serviceManager, IQueryProcessor queryProcessor) :
            base(commandProcessor, serviceManager, queryProcessor)
        { }

        public Response Print(OpenCommandRequest request)
        {
            //busco la configuracion de la impresora
            if (!GetPrinterConfiguration(request))
                return new Fail(String.Format("La impresora {0} no posee configuracion asociada o hay dos impresoras con el mismo nombre.", request.Document.Header.PrinterName));


            //chequeo que la impresora no esta reservada
            var reservations = GetReservation(request);
            if (reservations.Count() > 0)
                return new Fail("La impresora esta ocupada. Reintente en unos segundos.");

            //reservo la impresora sin expiration
            int reservationId = CreateReservation(request);

            //imprimo
            Task<string> result = _serviceManager.PrintAsync(request.Url, request.Document);

            //analizo respuesta y expiro si no hubo comunicacion
            if (result.Status != TaskStatus.RanToCompletion)
            {
                ExpirateReservation(reservationId);
                return new Fail(result.Exception.Message);
            }
            Response response = JsonConvert.DeserializeObject<Response>(result.Result);

            //si da error expiro la reserva
            if (response.Success == 0)
                ExpirateReservation(reservationId);
            else
            {
                //si todo va bien extiendo la reserva 10 segundos y devuelvo el id
                ExpirateReservation(reservationId, true);
                response.Reservation = reservationId.ToString();
            }
            return response;
        }
    }
}