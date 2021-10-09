using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationLibrary
{
    public class PagedList<T>: List<T>
    {
        private int CurrentPage { get; set; }
        private int TotalPages { get; set; }
        private int PageSize { get; set; }
        private int TotalCount { get; set; }
        private bool HasPrevious => CurrentPage > 1;
        private bool HasNext => CurrentPage < TotalPages;

        public PagedList() { }

        public PagedList( List<T> items, int count, int pageNumber, int pageSize) {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public object GetMetaData() {
            return new
            {
                CurrentPage,
                TotalPages,
                PageSize,
                TotalCount,
                HasPrevious,
                HasNext
            };
        }
    }
}
