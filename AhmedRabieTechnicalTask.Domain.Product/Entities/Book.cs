using AhmedRabieTechnicalTask.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Product.Entities
{
    public class Book:Entity
    {
        public Book(string title)
        {
            Title = title;
        }

        public Book(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Book()
        {

        }

        public string Title { get;  set; } 
        public string Description { get; set; }
        public double MinSalePrice { get; set; }
        public double MaxSalePrice { get; set; }
        public string Auther { get; set; }
        public DateTime PublishDate { get; set; }

        public bool Active { get;  set; } = true;
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
