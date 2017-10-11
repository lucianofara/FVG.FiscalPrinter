using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FVG.FiscalPrinter.Presentation.API.Helpers;
using Microsoft.Extensions.Options;
using FVG.FiscalPrinter.Presentation.API.Configuration;
using FVG.FiscalPrinter.Domain.Entities;
using FVG.FiscalPrinter.Domain.Core.ServiceManager;
using FVG.FiscalPrinter.Domain.Core.ServiceContract;

namespace Presentation.API.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommandPrintController : Controller
    {
        private IPrintProcessor _printProcessor;
        private ICommandProcessor _commandProcessor;
        private IOptions<APIUrl> _APIUrlOptions;

        public CommandPrintController(IPrintProcessor printProcessor, IOptions<APIUrl> APIUrlOptions,
                                    ICommandProcessor commandProcessor)
        {
            _printProcessor = printProcessor;
            _APIUrlOptions = APIUrlOptions;
            _commandProcessor = commandProcessor;
        }

        [HttpPost]
        public Response Post([FromBody]PrintDocument document)
        {
            CommandRequest request = new CommandRequest();
            request.Document = document;
            request.Url = _APIUrlOptions.Value.CommandUrl;

            return _printProcessor.PrintAsync<CommandRequest, Response>(request);
        }
    }
}