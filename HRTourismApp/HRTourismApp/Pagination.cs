using System.Collections.Generic;

namespace HRTourismApp
{
    public class Pagination
    {
        // Paging
        public int PageIndex { get; set; }
        public int ItemPerPage { get; set; }

        // Searching
        public string SearchBy { get; set; }

        // Sorting
        public string SortByProperty { get; set; }
        public string SortByValue { get; set; }

        // Filtering (For multiple filter)
        public List<string> FilterByProperty { get; set; }
        public List<string> FilterByValue { get; set; }

        public Pagination()
        {
            FilterByProperty = new List<string>();
            FilterByValue = new List<string>();
        }
    }
}
