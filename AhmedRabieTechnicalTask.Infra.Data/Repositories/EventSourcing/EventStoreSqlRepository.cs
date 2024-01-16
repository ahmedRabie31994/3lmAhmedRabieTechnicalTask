using AhmedRabieTechnicalTask.Domain.Core.Events;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            // return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
            return new List<StoredEvent>();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
