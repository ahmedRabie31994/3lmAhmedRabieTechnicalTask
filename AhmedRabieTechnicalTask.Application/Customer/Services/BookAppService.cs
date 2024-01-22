using AhmedRabieTechnicalTask.Application.Customer.Interfaces;
using AhmedRabieTechnicalTask.Application.Customer.Mapper;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Enums;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Customer.Interfaces;
using AhmedRabieTechnicalTask.Domain.Product.Entities;
using AhmedRabieTechnicalTask.Domain.Product.Interfaces;
using AhmedRabieTechnicalTask.Domain.Product.Models;
using AhmedRabieTechnicalTask.Infra.Data;
using AhmedRabieTechnicalTask.Infra.Data.Repositories;
using AhmedRabieTechnicalTask.Infra.Data.Repositories.EventSourcing;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieTechnicalTask.Application.Customer.Services
{
    public class BookAppService : IBookService
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBookRepository _BookRepository;

        public BookAppService(IEventStoreRepository eventStoreRepository,
                                  IBookRepository BookRepository)
        {

            _eventStoreRepository = eventStoreRepository;
            _BookRepository = BookRepository;

        }

        public ExecutionResponse<Book> Create(BookDto BookViewModel )
        {
            ExecutionResponse<AhmedRabieTechnicalTask.Domain.Product.Entities.Book> Response = new ExecutionResponse<Domain.Product.Entities.Book>();
            try
            {
                if (BookViewModel == null)
                { 
                    Response.Result = null;
                    Response.State = ResponsState.ValidationError;
                    Response.Message = "not valid Param";
                    Response.Exception = null; 
                } 
                var Book = BookMapping.Map(BookViewModel);
                var Added = _BookRepository.AddBook(Book);
                if (Added)
                {
                    Response.State = ResponsState.Success;
                    Response.Result = Book;
                }
            }
            catch (Exception ex)
            {
                Response.Result = null;
                Response.State = ResponsState.Error;
                Response.Exception = ex;

            }
            return Response;

        } 
        public BookSearchResult GetAll(BookParameter parameters)
        {
            if (parameters ==null)
            {
                return null;
            }
            var query = _BookRepository.GetAll(item => !item.Deleted);
            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                query = query.Where(item => item.Title.Contains(parameters.SearchQuery) || item.Description.Contains(parameters.SearchQuery) || item.Auther.Contains(parameters.SearchQuery));
            }
            var Res = Pagenation.PagedResult(query.OrderByDescending(z => z.PublishDate), parameters.PageNumber, parameters.PageSize);
            return new BookSearchResult()
            {
                currentPage = parameters.PageNumber,
                data = BookMapping.Map(Res.Data),
                succeeded = true,
                totalRecords = query.Count()
            }; 
        }

        public  async Task<BookDto> GetById(Guid id)
        {
            var Book = await _BookRepository.GetBookByIdAsync(id);
            return BookMapping.Map(Book);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookDto BookDtoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Activate(Guid id)
        {
            throw new NotImplementedException();
        } 
        public void Deactivate(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
