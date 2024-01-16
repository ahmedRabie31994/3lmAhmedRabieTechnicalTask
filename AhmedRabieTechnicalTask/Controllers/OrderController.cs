using AhmedRabieTechnicalTask.Application.Order.Interfaces;
using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Controllers
{
 
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderAppService;

        public OrderController(
            IOrderService OrderAppService)
        {
            _OrderAppService = OrderAppService;
        }
        [HttpGet]
        [Route("Order-management")]
        public IActionResult Get(OrderParameter parameters)
        {
            return Ok(_OrderAppService.GetAll(parameters));
        }
        [HttpGet]
        [Route("Order-management-GetByCustomerId/{id:guid}")]
        public IActionResult GetByCustomerId(Guid id)
        {
            return Ok(_OrderAppService.GetAllByCustomerId(id));
        }
        [HttpPost]
        [Route("Order-management")]
        public IActionResult Post([FromBody] PostOrderDto OrderViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest(OrderViewModel);
                }
                OrderViewModel.Id = Guid.NewGuid();
                var Model = _OrderAppService.Create(OrderViewModel);
                if (Model.State != Domain.Core.Enums.ResponsState.Success)
                {
                    return BadRequest(Model);
                }

                return Ok(Model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
