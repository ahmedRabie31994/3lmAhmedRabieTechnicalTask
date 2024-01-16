using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.ViewModels
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
       
         public DateTime CreatedDate { get; set; }
        public Guid? ProductId { get; set; }
         public int Quantity { get; set; }
        public bool Active { get;  set; }
        public double SalePrice { get; set; }

    }
    public class SingleOrderDetailDto
    {
        public Guid? OrderId { get; set; }
         public OrderDto Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ProductId { get; set; }
         public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public bool Active { get;   set; }
        public double SalePrice { get; set; }


    }
    public class PostOrderDetailDto
    {
        public Guid? OrderId { get; set; }
         public DateTime CreatedDate { get; set; }
        public Guid? ProductId { get; set; }
         public int Quantity { get; set; }
        public bool Active { get;    set; }
        public double SalePrice { get; set; }


    }
}
