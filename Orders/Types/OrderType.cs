using GraphQL.Types;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customers)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field<CustomerType>("customer", 
                resolve: context => customers.GetCustomerByIdAsync(context.Source.CustomerId));
            Field(o => o.CreatedDate);
        }
    }
}