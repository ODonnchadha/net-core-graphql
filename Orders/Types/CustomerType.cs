using GraphQL.Types;
using Orders.Models;

namespace Orders.Types
{
    public class CustomerType: ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}
