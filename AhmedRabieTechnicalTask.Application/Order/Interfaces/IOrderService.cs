using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<SingleOrderDto> GetAll(OrderParameter parameters);
        IEnumerable<SingleOrderDto> GetAllByCustomerId(Guid CustomerId);
        System.Threading.Tasks.Task<SingleOrderDto> GetById(Guid id);
        ExecutionResponse<AhmedRabieTechnicalTask.Domain.Customer.Entities.Order> Create(PostOrderDto OrderViewModel);
        void Update(OrderDto OrderViewModel);
        void Remove(Guid id);
        void Activate(Guid id);
        void Deactivate(Guid id);
    }
}
