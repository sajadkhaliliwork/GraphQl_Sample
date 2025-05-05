using GraphQL.Types;
using TestQl.Models;

namespace TestQl.GraphQL.Types;

public class BookType : ObjectGraphType<Book>
{
    public BookType ()
    {
        Field(x => x.Id).Description("شناسه کتاب");
        Field(x => x.Title).Description("عنوان کتاب");
        Field(x => x.Author).Description("نویسنده کتاب");
    }
}
