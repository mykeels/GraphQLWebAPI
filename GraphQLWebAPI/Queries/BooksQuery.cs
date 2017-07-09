using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLWebAPI.Repositories;
using GraphQLWebAPI.Models;

namespace GraphQLWebAPI.Queries
{
    public class BooksQuery : ObjectGraphType
    {
        public BooksQuery()
        {
            IBookRepository bookRepository = new BookRepository();
            Field<BookType>("book",
                            arguments: new QueryArguments(
                              new QueryArgument<StringGraphType>() { Name = "isbn" }),
                              resolve: context =>
                              {
                                  var id = context.GetArgument<string>("isbn");
                                  return bookRepository.BookByIsbn(id);
                              });

            Field<ListGraphType<BookType>>("books",
                                           resolve: context =>
                                           {
                                               return bookRepository.AllBooks();
                                           });
        }
    }
}