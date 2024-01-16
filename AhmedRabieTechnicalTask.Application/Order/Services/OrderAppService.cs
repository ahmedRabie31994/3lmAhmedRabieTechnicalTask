using AhmedRabieTechnicalTask.Application.Order.Interfaces;
using AhmedRabieTechnicalTask.Application.Order.Mappers;
using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Enums;
using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Application.Order.Services
{
    public class OrderAppService : IOrderService
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IOrderRepository _OrderRepository;
        private readonly IOrderDetailsRepository _OrderDetailsRepository;
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrderAppService(IOrderRepository OrderRepository,
                              IOrderDetailsRepository OrderDetailsRepository,
                                    IEventStoreRepository eventStoreRepository
                                 , ApplicationDbContext context, IUnitOfWork unitOfWork)
        {



            _eventStoreRepository = eventStoreRepository;
            _OrderDetailsRepository = OrderDetailsRepository;
            _OrderRepository = OrderRepository;
            _context = context;
            _unitOfWork = unitOfWork;

        }

        public ExecutionResponse<Domain.Customer.Entities.Order> Create(PostOrderDto OrderViewModel)
        {
            ExecutionResponse<AhmedRabieTechnicalTask.Domain.Customer.Entities.Order> Response = new ExecutionResponse<Domain.Customer.Entities.Order>();
            try
            {
                if (OrderViewModel == null || OrderViewModel.OrderDetails.Count<1)
                {

                    Response.Result = null;
                    Response.State = ResponsState.ValidationError;
                    Response.Message = "not valid object";
                    Response.Exception = null;

                }
              
                var Order = OrderMapper.Map(OrderViewModel);
                Order.CreatedDate = DateTime.Now;
                

                var NewOrder = _OrderRepository.AddOrderWithoutSave(Order);
                if (_unitOfWork.Commit())
                {
                    Response.State = ResponsState.Success;
                    Response.Result = NewOrder;
                }
            }
            catch (Exception ex)
            {
                Response.Result = null;
                Response.State = ResponsState.Error;
                Response.Exception = ex;

            }
            return Response;
        }



        public IEnumerable<SingleOrderDto> GetAll(OrderParameter parameters)
        {
            Expression<Func<AhmedRabieTechnicalTask.Domain.Customer.Entities.Order, bool>> expression = t => t.Deleted == parameters.Deleted;
            return OrderMapper.Map(_OrderRepository.GetAll(expression, parameters.PageNumber, parameters.PageSize).Include(c => c.OrderDetails));

        }

        public IEnumerable<SingleOrderDto> GetAllByCustomerId(Guid CustomerId)
        {
            Expression<Func<AhmedRabieTechnicalTask.Domain.Customer.Entities.Order, bool>> expression = t => t.Deleted == false &&t.CustomerId==CustomerId;
            return OrderMapper.Map(_OrderRepository.GetAll(expression, 1, 1000).Include(c => c.OrderDetails));
        }

        public  async Task<SingleOrderDto> GetById(Guid id)
        {

            var Order = await  _OrderRepository.GetOrderByIdAsync(id);
            return OrderMapper.Map(Order);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDto OrderViewModel)
        {
            throw new NotImplementedException();
        }
        public void Activate(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Deactivate(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
