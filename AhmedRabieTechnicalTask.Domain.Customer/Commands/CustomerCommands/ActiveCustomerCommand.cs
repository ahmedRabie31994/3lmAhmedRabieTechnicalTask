using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands
{
    public class ActiveCustomerCommand : CustomerCommand
    {
        public ActiveCustomerCommand(Guid id)
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

