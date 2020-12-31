using System.Collections.Generic;

namespace okta_aspnetcore_mvc_example.Models
{
    public class SearchResultsModel
    {
        public string SearchText { get; set; }
        
        public List<Order> Results { get; set; }
    }
}