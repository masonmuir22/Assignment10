using System;
namespace Assignment10v2.Models.ViewModels
{
   
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //calculation for total number of pages so we can dynamically build the number of pages we need to generate
        public int TotalPages => (int)(Math.Ceiling((float)TotalNumItems / ItemsPerPage));
    }
}
