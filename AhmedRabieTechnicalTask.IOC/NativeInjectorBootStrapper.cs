using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.Services;
using AhmedRabieTechnicalTask.Application.Order.Interfaces;
using AhmedRabieTechnicalTask.Application.Order.Services;
using AhmedRabieTechnicalTask.CrossCutting.Bus;
using AhmedRabieTechnicalTask.Domain.Core.Events;
using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Core.Notifications;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Domain.Product.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using AhmedRabieTechnicalTask.Infra.Data.EventSourcing;
using AhmedRabieTechnicalTask.Infra.Data.Repositories;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using AhmedRabieTechnicalTask.Infra.Data.UOW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
 using System;

namespace AhmedRabieTechnicalTask.IOC
{
    public class NativeInjectorBootStrapper
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            //services.AddScoped<AhmedRabieTechnicalTask.Domain.Core.Bus.IMediatRHandler, InMemoryBus>();
              
            // Infra - Data
             services.AddScoped<IUnitOfWork, UnitOfWork>();
 
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStored, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            //Book 
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookAppService>();

            //Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerAppService>();
            //Order 
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrderService, OrderAppService>();
        }
    }
}
