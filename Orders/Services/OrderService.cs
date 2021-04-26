using Orders.Events;
using Orders.Interfaces;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private IList<Order> orders;
        private readonly IOrderEventService events;

        public OrderService(IOrderEventService orderEventService)
        {
            this.orders = new List<Order>
            {
                new Order("1000", "250 Conference Brochures", DateTime.Now, 1, "24b9f878-7523-46e2-86e4-4421b9e9f4b5"),
                new Order("1001", "1600 Large Mallets", DateTime.Now.AddSeconds(40), 1, "8b72e049-af5d-44e8-876d-63d42029adcd"),
                new Order("2000", "250 T-Shirts", DateTime.Now.AddMinutes(5), 2, "0023d02d-0621-4eb9-8125-1ffd0ccff7fe"),
                new Order("3000", "500 Stickers", DateTime.Now.AddHours(3), 3, "825d7dc8-e8f3-418a-b2c9-9f3bf2ecf3da"),
                new Order("4000", "10 Posters", DateTime.Now.AddDays(-3), 4, "954a7327-4890-4e1e-9062-c07dcc5d4c14"),
            };

            this.events = orderEventService;
        }

        public Task<Order> CreateAsync(Order order)
        {
            orders.Add(order);

            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatus.CREATED, DateTime.Now);
            events.AddEvent(orderEvent);         
            
            return Task.FromResult(order);
        }

        public Task<Order> GetOrderByIdAsync(string id) => Task.FromResult(orders.Single(c => Equals(c.Id, id)));

        public Task<IEnumerable<Order>> GetOrdersAsync() => Task.FromResult(orders.AsEnumerable());

        public Task<Order> InitializeAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Init();

            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatus.PROCESSING, DateTime.Now);
            events.AddEvent(orderEvent);

            return Task.FromResult(order);
        }

        private Order GetById(string id)
        {
            var order = orders.SingleOrDefault(o => Equals(o.Id, id));
            if (order == null)
            {
                throw new ArgumentException(string.Format("Order Id {0} is invalid.", id));
            }

            return order;
        }
    }
}
