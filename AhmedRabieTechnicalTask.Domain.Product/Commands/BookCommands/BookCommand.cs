using AhmedRabieTechnicalTask.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands
{
    public abstract class BookCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Auther { get; protected set; } 
    }
}
