using GraphQL.Types;
using GraphQL;
using Orders.Queries;
using Orders.Mutations;
using Orders.Subscriptions;

namespace Orders.Schemas
{
    public class OrderSchema: Schema
    {
        public OrderSchema(
            OrderQuery query, 
            OrderMutation mutation, 
            OrderSubscription subscription,
            IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
