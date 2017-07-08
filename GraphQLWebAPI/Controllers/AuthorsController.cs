using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GraphQLWebAPI.Models;
using GraphQLWebAPI.Repositories;

namespace GraphQLWebAPI.Controllers
{
    public class AuthorsController: ApiController
    {
        private readonly BookRepository bookRepository = new BookRepository();
        // GET api/authors
        public IEnumerable<AuthorModel> Get()
        {
            return bookRepository.AllAuthors();
        }

        // GET api/authors/5
        public AuthorModel Get(int id)
        {
            return bookRepository.AuthorById(id);
        }

        // GET api/authors/book/5
        public AuthorModel Book(string isbn)
        {
            return bookRepository.BookByIsbn(isbn).Author;
        }
    }
}