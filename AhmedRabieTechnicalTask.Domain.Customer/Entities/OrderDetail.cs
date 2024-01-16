using AhmedRabieTechnicalTask.Domain.Core.Models;
using AhmedRabieTechnicalTask.Domain.Product.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Entities
{
    public class OrderDetail : Entity
    {
        public OrderDetail(Guid id, Guid orderId, Guid productId, int quantity)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;

        }

        public OrderDetail()
        {

        }

        public Guid? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product.Entities.Book Book { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
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
