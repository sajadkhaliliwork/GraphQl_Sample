// GraphQL/Query.cs
using GraphQL;
using GraphQL.Types;
using TestQl.GraphQL.Types;
using TestQl.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestQl.GraphQL;

public class BookQuery : ObjectGraphType
{
    public BookQuery()
    {
        // Field<ListGraphType<BookType>>(
        //    "books",
        //    resolve: context => GetBooks()
        //);
        Field<ListGraphType<BookType>>("books").Resolve(context =>DbTest. GetBooks());

        // Field<BookType>("Book",
        //arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
        //resolve: context =>
        //{
        //    var id = context.GetArgument<int>("id");
        //    return GetBooks().FirstOrDefault(b => b.Id == id);
        //});




        Field<BookType>("Book").Argument<IntGraphType>("id")
            .Resolve(context => DbTest.GetBooks()
            .FirstOrDefault(x => x.Id == context.GetArgument<int>("id"))
            );






    }

  
}


public class BookMutation :ObjectGraphType
{
    public BookMutation()
    {

    Field<BookType>("addBook").Argument<AddBookInputType>("input")
           .Resolve(context =>
           {
               var input = context.GetArgument<AddBookInput>("input");

              return  DbTest.AddBook( author:input.Author,title:input.Title); 


           });
    }

}