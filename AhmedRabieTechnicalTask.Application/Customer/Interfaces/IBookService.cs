using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Models;
using AhmedRabieTechnicalTask.Domain.Product.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.Interfaces
{
    public interface IBookService
    {
        BookSearchResult GetAll(BookParameter parameters);
        System.Threading.Tasks.Task<BookDto> GetById(Guid id);
        ExecutionResponse<AhmedRabieTechnicalTask.Domain.Product.Entities.Book> Create(BookDto BookViewModel);
        void Update(BookDto BookDtoViewModel);
        void Remove(Guid id);
        void Activate(Guid id);
        void Deactivate(Guid id);
    }
}
