using AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands;
using AhmedRabieTechnicalTask.Domain.Customer.Commands.OrderCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Validations.OrderValidation
{
    public class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.SalerName)
                .NotEmpty().WithMessage("Please ensure you have entered the Group Name")
                .Length(2, 100).WithMessage("The Customer Name must have between 2 and 100 characters");
        }

       
    }
}
