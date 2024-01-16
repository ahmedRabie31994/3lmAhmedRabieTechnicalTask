using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Entities;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepository(ApplicationDbContext context , IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public bool AddCustomer(Customer Customer)
        {
            if (Customer ==null)
            {
                return false;
            }
            _context.Add(Customer);
            if(_unitOfWork.Commit())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
     
        public Customer GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

        public Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return _context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Customer GetByEmail(string Email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == Email);
        }
    }
}
