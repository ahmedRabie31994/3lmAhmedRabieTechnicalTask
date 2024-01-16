using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.Mappers
{
    public static class OrderDetailsMapper
    {
        public static Domain.Customer.Entities.OrderDetail Map(PostOrderDetailDto item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new Domain.Customer.Entities.OrderDetail()
            {
               OrderId = item.OrderId,
               ProductId = item.ProductId , 
               Quantity =item.Quantity,
               SalePrice =item.SalePrice

               

            };
            return ReturnedObj;
        }
        public static OrderDetailDto Map(Domain.Customer.Entities.OrderDetail item)
        {
            if (item == null)
            {
                return null;
            }
            var ReturnedObj = new OrderDetailDto()
            {
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                SalePrice = item.SalePrice



            };
            return ReturnedObj;
        }
        public static IEnumerable< OrderDetailDto> Map(IEnumerable<Domain.Customer.Entities.OrderDetail> items)
        {
            if (items == null)
            {
                return null;
            }
            var ReturnedObj = items.Select(item => Map(item)).ToList();
            return ReturnedObj;
        }
        public static IEnumerable< Domain.Customer.Entities.OrderDetail> Map(IEnumerable <PostOrderDetailDto> items)
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
