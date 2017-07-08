using GraphQLWebAPI.Models;
using GraphQLWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GraphQLWebAPI.Controllers
{
    public class BooksController: ApiController
    {
        private readonly BookRepository bookRepository = new BookRepository();

        // GET api/values
        public IEnumerable<BookModel> Get()
        {
            return bookRepository.AllBooks();
        }

        // GET api/values/5
        public BookModel Get(string isbn)
        {
            return bookRepository.BookByIsbn(isbn);
        }
    }
}