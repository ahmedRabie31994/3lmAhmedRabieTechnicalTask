using AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Validations.CustomerValidation
{
    public class CustomerValidaion<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Group Name")
                .Length(2, 100).WithMessage("The Customer Name must have between 2 and 100 characters");
        }

        protected void ValidateAliasName()
        {
            RuleFor(c => c.AliasName)
                .NotEmpty().WithMessage("Please ensure you have entered the Group Name")
                .Length(2, 100).WithMessage("The Customer Alias Name must have between 2 and 100 characters");
        }
    }
}
