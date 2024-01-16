using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.Services;
using AhmedRabieTechnicalTask.Application.Order.Interfaces;
using AhmedRabieTechnicalTask.Application.Order.Services;
using AhmedRabieTechnicalTask.Domain.Core.Events;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using AhmedRabieTechnicalTask.Infra.Data.EventSourcing;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using AhmedRabieTechnicalTask.Infra.Data.Repositories;
using AhmedRabieTechnicalTask.Infra.Data.UOW;
using AhmedRabieTechnicalTask.IOC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using AhmedRabieTechnicalTask.Domain.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region add dependencies 
builder.Services.AddScoped<ApplicationDbContext>();

// ASP.NET HttpContext dependency
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Domain Bus (Mediator)
//services.AddScoped<AhmedRabieTechnicalTask.Domain.Core.Bus.IMediatRHandler, InMemoryBus>();

// Infra - Data
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Infra - Data EventSourcing
builder.Services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
builder.Services.AddScoped<IEventStored, SqlEventStore>();
builder.Services.AddScoped<EventStoreSqlContext>();



//Customer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerAppService>();
//Order 
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IOrderService, OrderAppService>();
#endregion

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run(); 
 