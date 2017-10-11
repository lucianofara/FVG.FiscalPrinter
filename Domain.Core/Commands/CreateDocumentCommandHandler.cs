using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
  
    public class CreateDocumentCommandHandler : _BaseHandler, ICommandHandler<CreateDocumentCommand>
    {
        public CreateDocumentCommandHandler(IDataContext db) : base(db)
        {
        }

        public void Handler(CreateDocumentCommand command)
        {
            _db.Add(command.Document).SaveChanges();
        }
    }
}