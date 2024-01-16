using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.ViewModels
{
    public class BookDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Book Title is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public double MinSalePrice { get; set; }
        public double MaxSalePrice { get; set; } 
        [Required(ErrorMessage = "The Auther is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Auther { get; set; }
        public DateTime PublishDate { get; set; } 
        public bool Active { get; set; }
    }
}
