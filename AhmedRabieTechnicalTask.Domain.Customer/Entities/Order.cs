using AhmedRabieTechnicalTask.Domain.Core.Enums;
using AhmedRabieTechnicalTask.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Entities
{
    public class Order : Entity
    {

        public Order(Guid id, string description, string salerName)
        {
            Id = id;
            Description = description;
            SalerName = salerName;
            OrderStatus = OrderStatus.Created;
        }

        public Order()
        {

        }

        public string Description { get;   set; }
        public string SalerName  { get;   set; }
        public Guid?  CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double Price { get; set; }
        public virtual ICollection<OrderDetail>  OrderDetails { get; set; }
        public bool Active { get; private set; } = true;
        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }


    }
}
