using System;

namespace Orders.Models
{
    public class OrderCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
