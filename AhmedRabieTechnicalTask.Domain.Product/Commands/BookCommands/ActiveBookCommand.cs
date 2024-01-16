using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands
{
    internal class ActiveBookCommand : BookCommand
    {
        public ActiveBookCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
