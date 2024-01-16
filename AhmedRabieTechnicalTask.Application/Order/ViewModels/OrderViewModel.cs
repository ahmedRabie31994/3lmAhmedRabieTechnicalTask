using AhmedRabieTechnicalTask.Application.Customer.ViewModels;
using AhmedRabieTechnicalTask.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Order.ViewModels
{
    public class OrderDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Saler Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string SalerName { get; set; }
        [Required(ErrorMessage = "The Customer alias  is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public double Price { get; set; }

        public OrderStatus OrderStatus { get; set; }

    }
    public class SingleOrderDto
    {
        public SingleOrderDto()
        {
            Customer = new CustomerDto();
        }
        [Key]
        public Guid Id { get; set; }

        public string SalerName { get; set; }

        public string Description { get; set; }
        public Guid? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public double Price { get; set; }

    }
    public class PostOrderDto
    {
        public Guid Id { get; set; }

        public string SalerName { get; set; }
        public Guid? CustomerId { get; set; }

        public string Description { get; set; }
        public CustomerDto Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double Price { get; set; }

        public List<PostOrderDetailDto> OrderDetails { get; set; }

    }
}
