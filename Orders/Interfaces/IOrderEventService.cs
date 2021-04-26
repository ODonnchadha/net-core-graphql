using Orders.Events;
using System;
using System.Collections.Concurrent;

namespace Orders.Interfaces
{
    public interface IOrderEventService
    {
        ConcurrentStack<OrderEvent> AllEvents { get; }
        void AddError(Exception exception);
        OrderEvent AddEvent(OrderEvent orderEvent);
        IObservable<OrderEvent> EventStream();
    }
}
