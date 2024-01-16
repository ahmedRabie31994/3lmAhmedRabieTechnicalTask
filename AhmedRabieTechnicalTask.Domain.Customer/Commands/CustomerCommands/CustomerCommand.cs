using AhmedRabieTechnicalTask.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands
{
    public abstract class CustomerCommand :Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string AliasName { get; protected set; }
    }
}
