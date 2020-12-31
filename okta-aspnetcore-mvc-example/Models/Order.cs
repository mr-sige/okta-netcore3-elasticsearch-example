using System;
using Nest;

namespace okta_aspnetcore_mvc_example.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Text(Name = "customer_full_name")]
        public string CustomerFullName { get; set; }
        
        [Date(Name = "order_date", Format = "MMddyyyy")]
        public DateTime OrderDate { get; set; }
        
        [Number(Name = "taxful_total_price")]
        public decimal TotalPrice { get; set; }
    }
}