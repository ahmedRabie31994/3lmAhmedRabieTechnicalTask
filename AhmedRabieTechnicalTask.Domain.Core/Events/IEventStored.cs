 using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Events
{
    public  interface IEventStored
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
