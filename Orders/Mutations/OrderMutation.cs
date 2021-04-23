using GraphQL.Types;
using Orders.Interfaces;
using Orders.Models;
using Orders.Types;
using System;

namespace Orders.Mutations
{
    public class OrderMutation: ObjectGraphType<object>
    {
        public OrderMutation(IOrderService orders)
        {
            Name = "Mutation";

            Field<OrderType>("createOrder", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderCreateType>> { Name="order" }), 
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderCreate>("order");

                    var id = Guid.NewGuid().ToString();
                    var order = new Order(
                        orderInput.Name,
                        orderInput.Description,
                        orderInput.CreatedDate,
                        orderInput.CustomerId, id);

                    return orders.CreateAsync(order);
                });

            FieldAsync<OrderType>("initializeOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<string>("orderId");
                    return await context.TryAsyncResolve(
                        async c => await orders.InitializeAsync(orderId));
                });
        }
    }
}
