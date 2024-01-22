using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.SearchResults
{
    public class BaseSearchResult
    { 
        public string message { get; set; }
        public bool succeeded { get; set; }
        public int totalRecords { get; set; } 
        public int currentPage { get; set; }
    }
}
