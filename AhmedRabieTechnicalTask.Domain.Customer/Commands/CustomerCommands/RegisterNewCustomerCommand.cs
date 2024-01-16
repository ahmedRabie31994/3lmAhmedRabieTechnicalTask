using AhmedRabieTechnicalTask.Domain.Customer.Validations.CustomerValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(Guid id, string name, string aliasName)
        {
            Id = id;
            Name = name;
            AliasName = aliasName;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

