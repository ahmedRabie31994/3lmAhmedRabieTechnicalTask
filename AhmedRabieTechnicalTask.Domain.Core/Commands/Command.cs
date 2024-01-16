using AhmedRabieTechnicalTask.Domain.Core.Events;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
 using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public abstract bool IsValid();
    }
}
