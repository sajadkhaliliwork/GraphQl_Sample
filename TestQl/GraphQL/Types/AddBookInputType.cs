using GraphQL.Types;
using TestQl.Models;

namespace TestQl.GraphQL.Types;

public class AddBookInputType : InputObjectGraphType<AddBookInput>
{
    public AddBookInputType()
    {
        //Name = "BookInput";
        Field(x => x.Title);
        Field(x=>x.Author);
    }
}