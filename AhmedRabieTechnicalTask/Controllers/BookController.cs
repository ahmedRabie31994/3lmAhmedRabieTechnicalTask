using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using AhmedRabieTechnicalTask.Domain.Product.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AhmedRabieTechnicalTask.Controllers
{
    //ahmed Mohamed Rabie
    [EnableCors("MyPloicy")]
    [Route("Book")] 
    public class BookController : ControllerBase
    {
        private readonly IBookService _BookAppService;
         
        public BookController(
            IBookService BookAppService)
        {
            _BookAppService = BookAppService;
        }
         
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(string searchQuery , int pageSize, int PageNumber)
        {
            BookParameter param =new BookParameter() { SearchQuery = searchQuery  ,PageSize=pageSize,PageNumber=PageNumber};
            return Ok(_BookAppService.GetAll(param));
        }
         
        [HttpPost]
        [Route("Book-management")]
        public IActionResult Post([FromBody] BookDto BookViewModel)
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
    }
}
