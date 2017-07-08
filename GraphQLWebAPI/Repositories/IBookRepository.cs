using GraphQLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLWebAPI.Repositories
{
    public interface IBookRepository
    {
        BookModel BookByIsbn(string isbn);
        IEnumerable<BookModel> AllBooks();

        AuthorModel AuthorById(int id);
        IEnumerable<AuthorModel> AllAuthors();

        PublisherModel PublisherById(int id);
        IEnumerable<PublisherModel> AllPublishers();
    }
}