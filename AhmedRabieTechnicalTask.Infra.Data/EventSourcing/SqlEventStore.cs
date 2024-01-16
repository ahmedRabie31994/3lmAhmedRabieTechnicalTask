using AhmedRabieTechnicalTask.Domain.Core.Events;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.EventSourcing
{
    public  class SqlEventStore : IEventStored
    {
        private readonly IEventStoreRepository _eventStoreRepository;
 
        public SqlEventStore(IEventStoreRepository eventStoreRepository )
        {
            _eventStoreRepository = eventStoreRepository;
             
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Test");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
