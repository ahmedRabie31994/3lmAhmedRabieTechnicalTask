using AhmedRabieTechnicalTask.Application.Order.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.ViewModels
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Customer Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Customer alias  is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string AliasName { get; set; }
        public string Email { get; set; }

        public bool Active { get; set; }
    }
    public class SingleCustomerDto
    {
        public SingleCustomerDto()
        {
            Orders = new List<OrderDto>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AliasName { get; set; }
        public string Email { get; set; }

        public bool Active { get; set; }
        public IList<OrderDto> Orders { get; set; }

    }

}
