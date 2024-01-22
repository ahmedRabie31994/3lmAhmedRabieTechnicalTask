using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data
{
    public static class Pagenation
    {
          public static PagedData<T> PagedResult<T>(this IQueryable<T> query, int PageNumber, int PageSize) where T : class
        {
            var result = new PagedData<T>();
            result.Data = query.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
            result.TotalPages = Convert.ToInt32(Math.Ceiling((double)query.Count() / PageSize));
            result.CurrentPage = PageNumber;
            result.TotalRecords = query.Count();
            return result;
        }

    }
    public class PagedData<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }

    }
}
