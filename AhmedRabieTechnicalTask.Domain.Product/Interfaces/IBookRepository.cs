using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Interfaces
{
    public interface IBookRepository : IRepository<Entities.Book>
    {  
        System.Threading.Tasks.Task<Entities.Book> GetBookByIdAsync(Guid id);
        bool AddBook(Entities.Book book);
    }
}
