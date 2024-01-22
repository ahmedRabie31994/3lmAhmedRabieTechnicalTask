using AhmedRabieTechnicalTask.Application.SearchResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Application.Customer.ViewModels
{
    public  class BookSearchResult : BaseSearchResult
    {
        public  IEnumerable<BookDto> data { get; set; }

    }
}
