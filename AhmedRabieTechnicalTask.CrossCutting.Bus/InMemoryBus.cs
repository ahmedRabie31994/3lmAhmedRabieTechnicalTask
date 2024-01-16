using AhmedRabieTechnicalTask.Domain.Core.Bus;
using AhmedRabieTechnicalTask.Domain.Core.Commands;
using AhmedRabieTechnicalTask.Domain.Core.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.CrossCutting.Bus
{
    public class InMemoryBus : IMediatRHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStored _eventStore;

        public InMemoryBus(IEventStored eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);
            return _mediator.Publish(@event);
        }
    }
}
