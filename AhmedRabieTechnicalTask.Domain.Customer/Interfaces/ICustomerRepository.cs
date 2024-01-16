using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Interfaces
{
    public  interface ICustomerRepository : IRepository<Entities.Customer>
    {
       Entities.Customer GetByName(string name);
       Entities.Customer GetByEmail(string Email);
        System.Threading.Tasks.Task<Entities.Customer> GetCustomerByIdAsync(Guid id);
        bool AddCustomer(Entities.Customer Customer);
     }
}
