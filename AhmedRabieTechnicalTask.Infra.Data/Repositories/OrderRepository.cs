using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Entities;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public bool AddOrder(Order Order)
        {
            if (Order == null)
            {
                return false;
            }

            _context.Add(Order);
            if (_unitOfWork.Commit())
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public Task<Order> GetOrderByIdAsync(Guid id)
        {
            return _context.Orders.Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Order AddOrderWithoutSave(Order Order)
        {
            try
            {
                if (Order == null)
                {
                    return null;
                }

               Create(Order);

                return Order;
            }
            catch
            {
                return null;
            }




        }
    }
}
