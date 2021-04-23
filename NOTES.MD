### API Development In .NET With GraphQL

- INTRODUCTION:
    - Using the GraphQL library to build the endpoint.
    - What is GraphQL.NET? Open-sourced .NET library. Stand-up an endpoint.
    - Declarative, fluent API.

- CREATING A NEW GRAPHQL PROJECT:

- EXPOSING A NEW GRAPHQL API:
    - Create models and services.
    - Use GraphQL.NET types, a query, and a schema.
        - Configuring the GraphQL Schema:
            1. Create GraphQL Types.
            2. Create a GraphQL Query object.
            3. Create a schema object to expose the query.
            4. Register the types in IoC.
        - Common GraphQL.NET CLasses:
            - Schema: Used to define query, mutation, and subscriptions.
            - ObjectGraph<T>: Used to expose GraphQL types in our schema. (Ability to "map.")
            - ListGraph<T>: Used to define a GraphQL collection.
            - ComplexGraphType<T>: Used to define fields within our types.
                - Field builder function creates these.
            - EnumerationGraphType: Used to define GraphQL enums.
    - Configure the GraphQL server.
    - Enable the server and run a query using GraphiQL.
    ```javascript
        query {
            orders {
                id
                name
                description
                customer {
                    id
                    name
                }
            }
        }
    ```

- ALLOWING UPDATES THROUGH MUTATIONS:
    - Enable mutations. How?
        - Update models and services.
        - Create mutation GraphQL types.
            - InputObjectGraphType: Defines an input type.
            - NonNullGraphType: Used to require a non-null value.
            - StringGraphType: Defines a string field.
            - IntGraphType: Yes. You guessed it.
            - DateGraphType: Defines a date field.
        - Update the schema.
        - Create a mutation and validate.
        ```javascript
            mutation createOrder($order: OrderInput!) {
                createOrder(order:$order) {
                    id
                    name
                    description
                    createdDate
                }
            }
        ```
        ```javascript
            {
            "order": {
                "name": "TEST",
                "description": "TESTORDER",
                "customerId": 1,
                "createdDate": "12-31-1968 07:00AM"
                }
            }
        ```            