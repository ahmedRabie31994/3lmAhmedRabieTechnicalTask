using AhmedRabieTechnicalTask.Domain.Core.Bus;
using AhmedRabieTechnicalTask.Domain.Core.Commands;
using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Core.Notifications;
using AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Domain.Customer.CommandHandlers
{
    class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand>
    {
        private readonly ICustomerRepository _CustomerRepository;
         private readonly IMediatRHandler Bus;
         public CustomerCommandHandler(ICustomerRepository CustomerRepository,
                                      IUnitOfWork uow,
                                       IMediatRHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _CustomerRepository = CustomerRepository;
             
            Bus = bus;
            
        }

        public Task<Unit> Handle(RegisterNewCustomerCommand message,CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var Customer = new AhmedRabieTechnicalTask.Domain.Customer.Entities.Customer(message.Id, message.Name, message.AliasName);

            _CustomerRepository.Add(Customer);

            if (Commit())
            {
                // TODO:
            }

            return Unit.Task;
        }

     
        
        

   
        public void Dispose()
        {
            _CustomerRepository.Dispose();
        }

        
    }
}
