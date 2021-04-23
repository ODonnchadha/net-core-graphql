using GraphQL.Types;

namespace Orders.Types
{
    public class OrderCreateType: InputObjectGraphType
    {
        public OrderCreateType()
        {
            Name = "OrderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<IntGraphType>>("customerId");
            Field<NonNullGraphType<DateGraphType>>("createdDate");
        }
    }
}
