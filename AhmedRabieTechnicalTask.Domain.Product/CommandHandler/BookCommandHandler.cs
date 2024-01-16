using AhmedRabieTechnicalTask.Domain.Core.Bus;
using AhmedRabieTechnicalTask.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AhmedRabieTechnicalTask.Domain.Product.Commands.BookCommands;
using AhmedRabieTechnicalTask.Domain.Product.Interfaces;
using AhmedRabieTechnicalTask.Domain.Core.Interfaces;

namespace AhmedRabieTechnicalTask.Domain.Product.CommandHandler
{
    public class BookCommandHandler : AhmedRabieTechnicalTask.Domain.Core.Commands.CommandHandler,
        IRequestHandler<RegisterNewBookCommand>
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMediatRHandler Bus;
        public BookCommandHandler(IBookRepository BookRepository,
                                     IUnitOfWork uow,
                                      IMediatRHandler bus,
                                     INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _BookRepository = BookRepository;

            Bus = bus;

        }

        public Task<Unit> Handle(RegisterNewBookCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var Customer = new AhmedRabieTechnicalTask.Domain.Product.Entities.Book(message.Id, message.Title);

            _BookRepository.Add(Customer);

            if (Commit())
            {
                // TODO:
            }

            return Unit.Task;
        }






        public void Dispose()
        {
            _BookRepository.Dispose();
        }


    }
}
