using System;

namespace Orders.Models
{
    [Flags()]
    public enum OrderStatus
    {
        CREATED=2, PROCESSING=4, COMPLETED=8, CANCELLED=16, CLOSED=32
    }
    public class Order
    {
        public string Name { get; set;  }
        public string Description { get; set; }
        public DateTime CreatedDate { get; private set; }
        public int CustomerId { get; set;  }
        public string Id { get; private set; }
        public OrderStatus Status { get; private set; }
        public Order(string name, string description, DateTime createdDate, int customerId, string id)
        {
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            CustomerId = customerId;
            Id = id;
            Status = OrderStatus.CREATED;
        }

        public void Init() => Status = OrderStatus.PROCESSING;
    }
}
