### API Development In .NET With GraphQL

- INTRODUCTION:
    - By Glenn Block.
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
        query getOrders {
        orders {
            id
            name
            description
            customer {
                name
            }
            createdDate
            status
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

            mutation initializeOrder(orderId:$id) {
                    id
                    status
                }
            }
        ```
        ```javascript
            "order": {
                "name": "TEST",
                "description": "TESTORDER",
                "customerId": 1,
                "createdDate": "12-31-1968 07:00AM"
            },
            "id": "24b9f878-7523-46e2-86e4-4421b9e9f4b5"
            }
        ```

- ALLOWING CLIENTS TO SUBSCRIBE TO NOTIFICATIONS:
    - What are subscriptions? Allow real-time notifications to GraphQL clients through a push model.
    - Via WebSockets, traditionally. Clients subscribe to notifications of interest.
    - An event occurs in the system and is published to the GraphQL server.
    - How to enable?
        - Update models and services.
        - Create a new event GraphQL type.
        - Create a subscription.
        - Update the schema.
        - Configure the GraphQL server.
        - Use three (3) instances to test and validate subscriptions.
    
    - New GraphQL.NET Schema Classes:
        - ResolveFieldContext: Context passed into the resolver for a field.
        - FuncFieldResolver: Delegate that is invoked to resolve a field value.
        - EventStreamFieldType: Used for adding an event stream field to a GraphQL type.
        - EventStreamResolver: Delegate for handling subscriptions to an event stream field.
        - ResolveEventStreamCOntext: Context passed into the EventStreamResolver.
    
    ```javascript
        subscription {
            orderEvent(statuses: [CREATED]) {
                orderId
                name
                status
            }
        }
        subscription {
            orderEvent(statuses: [PROCESSING]) {
                orderId
                name
                status
            }
        }
        >> "Your subscription data will appear here after server publication!"
    ```

- NEXT STEPS:
    - Learning Apollo.