using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using AhmedRabieTechnicalTask.Domain.Product.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AhmedRabieTechnicalTask.Controllers
{  
    public class BookController : ControllerBase
    {
        private readonly IBookService _BookAppService;

        public BookController(
            IBookService BookAppService)
        {
            _BookAppService = BookAppService;
        }

        [HttpGet]
        [Route("Book-management")]
        public IActionResult Get(BookParameter parameters)
        {
            return Ok(_BookAppService.GetAll(parameters));
        }

        [HttpPost]
        [Route("Book-management")]
        public IActionResult Post([FromBody] BookDto BookViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest(BookViewModel);
                }
                BookViewModel.Id = Guid.NewGuid();
                var Model = _BookAppService.Create(BookViewModel);
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
