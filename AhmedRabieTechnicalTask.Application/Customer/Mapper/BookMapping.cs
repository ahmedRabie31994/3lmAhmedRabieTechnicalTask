using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.Mapper
{
    public  class BookMapping
    {
        public static Domain.Product.Entities.Book Map(BookDto item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new Domain.Product.Entities.Book()
            {
                Title = item.Title,
                Description = item.Description,
                Auther = item.Auther,
                Active = item.Active,
                MaxSalePrice = item.MaxSalePrice,   
                MinSalePrice = item.MinSalePrice,
                PublishDate= item.PublishDate  
            };
            return ReturnedObj;
        }
        public static BookDto Map(Domain.Product.Entities.Book item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new BookDto()
            {
                Title = item.Title,
                Description = item.Description,
                Auther = item.Auther,
                Active = item.Active,
                MaxSalePrice = item.MaxSalePrice,
                MinSalePrice = item.MinSalePrice,
                PublishDate = item.PublishDate 
            };
            return ReturnedObj;
        }
        public static IEnumerable<BookDto> Map(IEnumerable<Domain.Product.Entities.Book> items)
        {
            if (items == null)
            {
                return null;
            }
            var ReturnedObj = items.Select(item => Map(item)).ToList();
            return ReturnedObj;
        }
    }
}
