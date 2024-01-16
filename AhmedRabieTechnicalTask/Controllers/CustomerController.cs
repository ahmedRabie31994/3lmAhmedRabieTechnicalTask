using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.Services;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Controllers
{ 
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerAppService;

        public CustomerController(
            ICustomerService CustomerAppService)
        {
            _CustomerAppService = CustomerAppService;
        }
        [HttpGet]
        [Route("Customer-management")]
        public IActionResult Get(CustomerParameter parameters)
        {
            return Ok(_CustomerAppService.GetAll(parameters));
        }
        [HttpPost]
        [Route("Customer-management")]
        public IActionResult Post([FromBody] CustomerDto CustomerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest(CustomerViewModel);
                }
                CustomerViewModel.Id = Guid.NewGuid();
                var Model = _CustomerAppService.Create(CustomerViewModel);
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
