using AhmedRabieTechnicalTask.Domain.Core.Commands;
using AhmedRabieTechnicalTask.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Domain.Core.Bus
{
    public interface IMediatRHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
