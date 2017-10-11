using FVG.FiscalPrinter.Domain.Core.ServiceContract;
using FVG.FiscalPrinter.Domain.Core.ServiceManager;
using FVG.FiscalPrinter.Domain.Entities;
using FVG.FiscalPrinter.Presentation.API.Configuration;
using FVG.FiscalPrinter.Presentation.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestPrintController : Controller
    {
        private IPrintProcessor _printProcessor;
        private ICommandProcessor _commandProcessor;
        private IOptions<APIUrl> _APIUrlOptions;

        public TestPrintController(IPrintProcessor printProcessor, IOptions<APIUrl> APIUrlOptions,
                                    ICommandProcessor commandProcessor)
        {
            _printProcessor = printProcessor;
            _APIUrlOptions = APIUrlOptions;
            _commandProcessor = commandProcessor;
        }

        [HttpPost]
        public Response Post([FromBody]PrintDocument document)
        {
            TestRequest request = new TestRequest();
            request.Document = document;
            request.Url = _APIUrlOptions.Value.TestUrl;

            return _printProcessor.PrintAsync<TestRequest, Response>(request);
        }
    }
}