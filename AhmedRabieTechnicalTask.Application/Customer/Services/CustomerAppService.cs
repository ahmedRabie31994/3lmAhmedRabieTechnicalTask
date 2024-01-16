using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.Mapper;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Bus;
using AhmedRabieTechnicalTask.Domain.Core.Enums;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Commands.CustomerCommands;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Application.Customer.Services
{
    public class CustomerAppService : ICustomerService
    {


        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerAppService(
                                    IEventStoreRepository eventStoreRepository,
                                  ICustomerRepository CustomerRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            _CustomerRepository = CustomerRepository;

        }
        public IEnumerable<CustomerDto> GetAll(CustomerParameter parameters)
        {
            Expression<Func<AhmedRabieTechnicalTask.Domain.Customer.Entities.Customer, bool>> expression = t => t.Deleted == parameters.Deleted;
            return CustomerMapping.Map(_CustomerRepository.GetAll(expression, parameters.PageNumber, parameters.PageSize).Include(c => c.Orders));

        }

        public async Task<CustomerDto> GetById(Guid id)
        {
            var Customer = await _CustomerRepository.GetCustomerByIdAsync(id);
            return CustomerMapping.Map(Customer);
        }
        public ExecutionResponse<AhmedRabieTechnicalTask.Domain.Customer.Entities.Customer> Create(CustomerDto customerViewModel)
        {
         
            ExecutionResponse<AhmedRabieTechnicalTask.Domain.Customer.Entities.Customer> Response = new ExecutionResponse<Domain.Customer.Entities.Customer>();
            try
            {
                if (customerViewModel == null)
                {

                    Response.Result = null;
                    Response.State = ResponsState.ValidationError;
                    Response.Message = "not valid Param";
                    Response.Exception = null;

                }
                var chechCustomerByEmail = _CustomerRepository.GetByEmail(customerViewModel.Email);
                if (chechCustomerByEmail!=null)
                {
                    Response.Result = null;
                    Response.State = ResponsState.ValidationError;
                    Response.Message = "this Email has been taken";
                    Response.Exception = null;
                    
                    return Response;
                }
                var customer = CustomerMapping.Map(customerViewModel);
                
                var Added = _CustomerRepository.AddCustomer(customer);
                if (Added)
                {
                    Response.State = ResponsState.Success;
                    Response.Result = customer;
                }
            }
            catch(Exception ex)
            {
                Response.Result = null;
                Response.State = ResponsState.Error;
                Response.Exception = ex;

            }
            return Response;
        }
        //public void Create(CustomerDto customerViewModel)
        //{
        //    throw new NotImplementedException();


        //}

        public void Deactivate(Guid id)
        {
            throw new NotImplementedException();
        }




        public void Activate(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerDto customerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
