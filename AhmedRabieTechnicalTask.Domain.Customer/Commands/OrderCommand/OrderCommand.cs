using AhmedRabieTechnicalTask.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Commands.OrderCommand
{
    public abstract class OrderCommand :Command
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public string SalerName { get; protected set; }
        public int CustomerId { get; set; }
    }
}
