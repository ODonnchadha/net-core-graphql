using GraphQL.Types;
using Orders.Events;

namespace Orders.Types
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.OrderId);
            Field<OrderStatusType>("status", resolve: context => context.Source.Status);
            Field(e => e.Timestamp);
        }
    }
}
