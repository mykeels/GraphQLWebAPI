using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLWebAPI.Models
{
    public class BookType : ObjectGraphType<BookModel>
    {
        public BookType()
        {
            Field(x => x.Isbn).Description("The isbn of the book.");
            Field(x => x.Name).Description("The name of the book.");
            Field<AuthorType>("author");
        }
    }

    public class AuthorType : ObjectGraphType<AuthorModel>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("The id of the author.");
            Field(x => x.Name).Description("The name of the author.");
            Field<BookType>("books");
        }
    }
}