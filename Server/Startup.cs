using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Orders.Interfaces;
using Orders.Mutations;
using Orders.Queries;
using Orders.Schemas;
using Orders.Services;
using Orders.Types;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IOrderService, OrderService>();

            services.AddSingleton<CustomerType>();
            services.AddSingleton<OrderCreateType>();
            services.AddSingleton<OrderStatusType>();
            services.AddSingleton<OrderType>();

            services.AddSingleton<OrderMutation>();

            services.AddSingleton<OrderSchema>();
            services.AddSingleton<OrderQuery>();

            // NOTE: Whenever any object is constructed by GraphQL that needs to access a depencency,
            // such as a service, this is the code that will run and resolve.
            services.AddSingleton<IDependencyResolver>(
                d => new FuncDependencyResolver(type => d.GetRequiredService(type)));

            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<OrderSchema>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseWebSockets();
            app.UseGraphQLWebSocket<OrderSchema>(new GraphQLWebSocketsOptions());
            app.UseGraphQLHttp<OrderSchema>(new GraphQLHttpOptions());
        }
    }
}
