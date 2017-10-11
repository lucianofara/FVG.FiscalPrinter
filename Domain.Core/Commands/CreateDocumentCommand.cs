using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FVG.FiscalPrinter.Domain.Core.Commands
{
    public class CreateDocumentCommand : ICommand
    {
        public Document Document { get; set; }

        public CreateDocumentCommand(Document document)
        {
            this.Document = document;
        }
    }
}
