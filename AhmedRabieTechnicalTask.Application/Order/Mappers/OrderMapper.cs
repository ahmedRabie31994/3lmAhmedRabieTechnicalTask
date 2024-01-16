using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.Mappers
{
    public static class OrderMapper
    {
        public static Domain.Customer.Entities.Order Map(SingleOrderDto item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new Domain.Customer.Entities.Order()
            {
               SalerName = item.SalerName ,
               CustomerId = item.CustomerId, 
               Description =item.Description,

                Price = item.Price,


            };
            return ReturnedObj;
        }
        public static Domain.Customer.Entities.Order Map(PostOrderDto item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new Domain.Customer.Entities.Order()
            {
                SalerName = item.SalerName,
                CustomerId = item.CustomerId,
                Description = item.Description,
                OrderStatus =item.OrderStatus,
                Price =item.Price,
                OrderDetails = item.OrderDetails.Count() > 0 ?   OrderDetailsMapper.Map(item.OrderDetails).ToList() :null,
                 
            };
            return ReturnedObj;
        }
        public static SingleOrderDto Map(Domain.Customer.Entities.Order item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new SingleOrderDto()
            {
                SalerName = item.SalerName,
                CustomerId = item.CustomerId,
                Description = item.Description,
                OrderDetails = item.OrderDetails.Count() > 0 ? OrderDetailsMapper.Map(item.OrderDetails).ToList() : null,
                Price= item.Price,



            };
            return ReturnedObj;
        }
       
        public static IEnumerable<SingleOrderDto> Map(IEnumerable< Domain.Customer.Entities.Order> items)
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
