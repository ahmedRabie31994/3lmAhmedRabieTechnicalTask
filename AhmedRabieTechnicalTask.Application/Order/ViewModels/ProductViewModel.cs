using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.ViewModels
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get;   set; }
        public string AliasName { get;   set; }
        public string Description { get; set; }
        public double minSalePrice { get; set; }
        public double MaxSalePrice { get; set; }

    }
    public class SingleProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
        public string Description { get; set; }
        public double minSalePrice { get; set; }
        public double MaxSalePrice { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; }

    }
}
