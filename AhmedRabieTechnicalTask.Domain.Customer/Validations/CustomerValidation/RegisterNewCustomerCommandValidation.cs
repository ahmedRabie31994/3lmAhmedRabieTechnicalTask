using AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Validations.CustomerValidation
{
   public class RegisterNewCustomerCommandValidation : CustomerValidation.CustomerValidaion<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateAliasName();
        }
    }
}
