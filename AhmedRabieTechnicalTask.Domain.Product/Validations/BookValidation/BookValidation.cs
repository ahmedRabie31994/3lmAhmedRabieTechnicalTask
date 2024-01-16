using AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Validations.BookValidation
{
    internal class BookValidation<T> : AbstractValidator<T> where T : BookCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please ensure you have entered the Title of Book")
                .Length(2, 100).WithMessage("The Book Title must have between 5 and 100 characters");
        }

        protected void ValidateAuther()
        {
            RuleFor(c => c.Auther)
                .NotEmpty().WithMessage("Please ensure you have entered the auther Name")
                .Length(2, 100).WithMessage("The Auther must have between 2 and 100 characters");
        }
    }
}
