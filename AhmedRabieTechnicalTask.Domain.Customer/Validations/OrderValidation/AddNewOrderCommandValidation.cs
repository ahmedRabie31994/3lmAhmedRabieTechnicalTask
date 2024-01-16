using AhmedRabieTechnicalTask.Domain.Customer.Commands.OrderCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Validations.OrderValidation
{
    public class AddNewOrderCommandValidation : OrderValidation.OrderValidation<AddNewOrderCommand>
    {
        public AddNewOrderCommandValidation()
        {
            ValidateName();
         }
    }
}
