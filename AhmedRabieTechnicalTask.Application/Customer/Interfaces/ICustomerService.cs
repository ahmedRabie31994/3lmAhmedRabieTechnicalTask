using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll(CustomerParameter parameters);
        System.Threading.Tasks.Task<CustomerDto> GetById(Guid id);
        ExecutionResponse<AhmedRabieTechnicalTask.Domain.Customer.Entities.Customer> Create(CustomerDto customerViewModel);
        void Update(CustomerDto customerViewModel);
        void Remove(Guid id);
        void Activate(Guid id);
        void Deactivate(Guid id);
     }
}
