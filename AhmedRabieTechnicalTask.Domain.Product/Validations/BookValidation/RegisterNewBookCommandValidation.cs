using AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Validations.BookValidation
{
    internal class RegisterNewBookCommandValidation : BookValidation.BookValidation<RegisterNewBookCommand>
    {
        public RegisterNewBookCommandValidation()
        {
            ValidateTitle();
            ValidateAuther();
        }
    }
}