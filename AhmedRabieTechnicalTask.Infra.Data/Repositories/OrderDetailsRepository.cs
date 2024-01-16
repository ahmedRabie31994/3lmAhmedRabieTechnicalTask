using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Entities;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories
{
    public class OrderDetailsRepository: Repository<OrderDetail>, IOrderDetailsRepository
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailsRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
    }
}
