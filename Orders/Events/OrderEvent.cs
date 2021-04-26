using Orders.Models;
using System;

namespace Orders.Events
{
    public class OrderEvent
    {
        public string Id { get; private set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Timestamp { get; private set; }
        public OrderEvent(string orderId, string name, OrderStatus status, DateTime timestamp)
        {
            this.Id = Guid.NewGuid().ToString();

            OrderId = orderId;
            Name = name;
            Status = status;
            Timestamp = timestamp;
        }
    }
}
