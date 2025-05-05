
using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using TestQl.GraphQL;
using TestQl.GraphQL.Types;

namespace TestQl
{
    public class Program
    {
        public static void Main ( string[] args )
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();  
            // Add services to the container.
            builder.Services.AddGraphQL(b => b
                .AddSchema<BookSchema>()
                .AddGraphTypes(typeof(BookSchema).Assembly)// Adds all schema types
                .AddSystemTextJson());       // Serializer

            // Register custom types
            //builder.Services.AddSingleton<BookType>();
            //builder.Services.AddSingleton<BookQuery>();
            //builder.Services.AddSingleton<BookMutation>();
            //builder.Services.AddSingleton<ISchema, BookSchema>();
            //builder. Services.AddSingleton<AddBookInputType>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            // Add GraphQL endpoint
            app.UseGraphQL<BookSchema>();//("gql");
            app.UseGraphQLPlayground();
     
            app.MapControllers();
            app.Run();
        }
    }
}
