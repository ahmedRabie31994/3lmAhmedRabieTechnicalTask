using AhmedRabieTechnicalTask.Domain.Product.Validations.BookValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands
{
    public class RegisterNewBookCommand : BookCommand
    {
        public RegisterNewBookCommand(Guid id, string title, string auther)
        {
            Id = id;
            Title = title;
            Auther = auther; 
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
