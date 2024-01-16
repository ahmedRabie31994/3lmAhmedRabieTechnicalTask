using AhmedRabieTechnicalTask.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
