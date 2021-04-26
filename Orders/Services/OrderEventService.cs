using Orders.Events;
using Orders.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Orders.Services
{
    public class OrderEventService : IOrderEventService
    {
        private readonly ISubject<OrderEvent> eventStream = new ReplaySubject<OrderEvent>(1);
        public ConcurrentStack<OrderEvent> AllEvents { get; }
        public OrderEventService() => AllEvents = new ConcurrentStack<OrderEvent>();
        public void AddError(Exception exception) => eventStream.OnError(exception);
        public IObservable<OrderEvent> EventStream() => eventStream.AsObservable();
        public OrderEvent AddEvent(OrderEvent orderEvent)
        {
            AllEvents.Push(orderEvent);
            eventStream.OnNext(orderEvent);


            return orderEvent;
        }
    }
}
