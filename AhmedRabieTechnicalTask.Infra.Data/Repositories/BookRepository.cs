using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using AhmedRabieTechnicalTask.Domain.Customer.Entities;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Domain.Product.Entities;
using AhmedRabieTechnicalTask.Domain.Product.Interfaces;
using AhmedRabieTechnicalTask.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public bool AddBook(Book book)
        {
            if (book == null)
            {
                return false;
            }
            _context.Add(book);
            if (_unitOfWork.Commit())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public   Task<Book> GetBookByIdAsync(Guid id)
        {
            return  _context.Books.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
