using GraphQL.Types;
using Orders.Interfaces;
using Orders.Types;

namespace Orders.Queries
{
    public class OrderQuery: ObjectGraphType<object>
    {
        public OrderQuery(IOrderService orders)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>("orders", resolve: context => orders.GetOrdersAsync());
        }
    }
}
