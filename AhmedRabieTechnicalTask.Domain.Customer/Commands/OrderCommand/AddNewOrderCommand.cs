using AhmedRabieTechnicalTask.Domain.Core.Commands;
using AhmedRabieTechnicalTask.Domain.Customer.Validations.OrderValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Commands.OrderCommand
{
    public   class AddNewOrderCommand :OrderCommand
    {
        public AddNewOrderCommand(Guid id, int customerId, string salerName, string description)
        {
            Id = id;
            CustomerId = customerId;
            SalerName = salerName;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
