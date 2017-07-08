using GraphQLWebAPI.Models;
using GraphQLWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GraphQLWebAPI.Controllers
{
    public class PublishersController: ApiController
    {
        private readonly BookRepository bookRepository = new BookRepository();
        // GET api/publishers
        public IEnumerable<PublisherModel> Get()
        {
            return bookRepository.AllPublishers();
        }

        // GET api/publishers/5
        public PublisherModel Get(int id)
        {
            return bookRepository.PublisherById(id);
        }

        // GET api/publishers/book/5
        public PublisherModel Book(string isbn)
        {
            return bookRepository.BookByIsbn(isbn).Publisher;
        }
    }
}