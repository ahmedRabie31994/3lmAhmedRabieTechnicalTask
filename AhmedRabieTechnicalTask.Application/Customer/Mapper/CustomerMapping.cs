using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AhmedRabieTechnicalTask;
using AhmedRabieTechnicalTask.Application.Customer.ViewModels;

namespace AhmedRabieTechnicalTask.Application.Customer.Mapper
{
    public class CustomerMapping
    {
        public static Domain.Customer.Entities.Customer   Map(CustomerDto item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new Domain.Customer.Entities.Customer()
            {
                Name = item.Name,
                AliasName = item.AliasName,
                Email = item.Email,
                Active = item.Active,


            };
            return ReturnedObj;
        }
        public static CustomerDto Map(Domain.Customer.Entities.Customer item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new CustomerDto()
            {
                Name = item.Name,
                AliasName = item.AliasName,
                Email = item.Email,
                Active = item.Active,


            };
            return ReturnedObj;
        }
        public static IEnumerable<CustomerDto> Map(IEnumerable<Domain.Customer.Entities.Customer> items)
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
