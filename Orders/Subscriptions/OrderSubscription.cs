using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using Orders.Events;
using Orders.Interfaces;
using Orders.Models;
using Orders.Types;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Orders.Subscriptions
{
    public class OrderSubscription : ObjectGraphType<object>
    {
        private readonly IOrderEventService events;
        public OrderSubscription(IOrderEventService orderEventService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "orderEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<OrderStatusType>>
                {
                    Name = "statuses"
                }),
                Type = typeof(OrderEventType),
                Resolver = new FuncFieldResolver<OrderEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<OrderEvent>(Subscribe)
            });

            this.events = orderEventService;
        }

        private OrderEvent ResolveEvent(ResolveFieldContext context)
        {
            var orderEvent = context.Source as OrderEvent;

            return orderEvent;
        }

        private IObservable<OrderEvent> Subscribe(ResolveEventStreamContext context)
        {
            var statusList = context.GetArgument<IList<OrderStatus>>("statuses",
                new List<OrderStatus>());

            if (statusList.Count > 0)
            {
                OrderStatus statuses = 0;
                foreach(var status in statusList)
                {
                    statuses = statuses | status;
                }

                return events.EventStream().Where(e => (e.Status & statuses) == e.Status);
            }
            else
            {
                return events.EventStream();
            }
        }
    }
}
