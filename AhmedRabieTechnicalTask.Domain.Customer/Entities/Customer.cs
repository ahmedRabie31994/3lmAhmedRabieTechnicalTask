using AhmedRabieTechnicalTask.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Customer.Entities
{
    [Table("Customer")]

    public class Customer :Entity
    {
        public Customer(string name)
        {
            Name = name;
        }

        public Customer(Guid id, string name, string aliasName)
        {
            Id = id;
            Name = name;
            AliasName = aliasName;
         }

        public Customer()
        {
          
        }

        public string Name { get;  set; }
        public string AliasName { get;  set; }
        public string Email { get; set; }

        public bool Active { get;  set; } = true;
        public ICollection<Order> Orders { get; set; }
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
