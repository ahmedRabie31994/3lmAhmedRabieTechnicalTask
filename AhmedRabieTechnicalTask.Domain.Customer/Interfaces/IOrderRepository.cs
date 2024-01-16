using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Interfaces
{
    public interface IOrderRepository :IRepository<Entities.Order>
    {
        
        System.Threading.Tasks.Task<Entities.Order> GetOrderByIdAsync(Guid id);
        bool AddOrder(Entities.Order Order);
        Entities.Order AddOrderWithoutSave(Entities.Order Order);
    }
}
