using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Models
{
    public class BaseParameter
    {

        const int maxPageSize = 1000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 50;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string SearchQuery { get; set; }
        public virtual string OrderBy { get; set; } = "id";
         public bool? Deleted { get; set; } = false;
    }
}
