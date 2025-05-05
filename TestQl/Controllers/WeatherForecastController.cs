using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Client.Serializer.SystemTextJson;
using TestQl.Models;

namespace TestQl.Controllers
{
    public class BookData
    {
        public List<Book> Books { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController ( ILogger<WeatherForecastController> logger )
        {
            _logger=logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Book>> GetAsync ()
        {
            var graphqlEndpoint = "https://localhost:7277/graphql"; // آدرس سرور GraphQL شما

    

            var options = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(graphqlEndpoint)
            };

            // استفاده از System.Text.Json
            var client = new GraphQLHttpClient(options, new SystemTextJsonSerializer());



            //  var client = new GraphQLHttpClient(graphqlEndpoint, new SystemTextJsonSerializer());


            var request = new GraphQLRequest
            {
                Query = @"
                {
                    books {
                        id
                        title
                        author
                    }
                }"
            };

            var response = await client.SendQueryAsync<BookData>(request);


            if (response.Errors != null)
            {
                //Console.WriteLine("خطا:");
                //foreach (var err in response.Errors)
                //    Console.WriteLine(err.Message);
                throw new Exception(response.Errors.ToString());
            }
            else
            {
                return response.Data.Books;
                //foreach (var book in response.Data.Books)
                //{
                //    Console.WriteLine($"ID: {book.Id}, عنوان: {book.Title}, نویسنده: {book.Author}");
                //}
            }
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date=DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC=Random.Shared.Next(-20, 55),
            //    Summary=Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
