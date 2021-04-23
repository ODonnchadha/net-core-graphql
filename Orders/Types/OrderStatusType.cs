using GraphQL.Types;

namespace Orders.Types
{
    public class OrderStatusType : EnumerationGraphType
    {
        public OrderStatusType()
        {
            Name = "OrderStatus";
            AddValue("CREATED", "Order was created", 2);
            AddValue("PROCESSING", "Order is being processed", 4);
            AddValue("COMPLETED", "Order is completed", 8);
            AddValue("CANCELLED", "Order was cancelled", 16);
            AddValue("CLOSED", "Order is closed", 32);
        }
    }
}
