using GraphQL.Types;
using GraphQL;
using Orders.Queries;
using Orders.Mutations;

namespace Orders.Schemas
{
    public class OrderSchema: Schema
    {
        public OrderSchema(OrderQuery query, OrderMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}
