using GraphQLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLWebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static IEnumerable<BookModel> _books = new List<BookModel>();
        private static IEnumerable<AuthorModel> _authors = new List<AuthorModel>();
        private static IEnumerable<PublisherModel> _publisher = new List<PublisherModel>();

        public BookRepository()
        {
            if (_books.Count() == 0)
            {
                _books = BookModel.GetBooks(10).ToList();
                _authors = _books.Select(book => book.Author).ToList();
                _publisher = _books.Select(book => book.Publisher).ToList();
            }
        }

        public IEnumerable<AuthorModel> AllAuthors()
        {
            return _authors;
        }

        public IEnumerable<BookModel> AllBooks()
        {
            return _books;
        }

        public IEnumerable<PublisherModel> AllPublishers()
        {
            return _publisher;
        }

        public AuthorModel AuthorById(int id)
        {
            return _authors.First(_ => _.Id == id);
        }

        public BookModel BookByIsbn(string isbn)
        {
            return _books.First(_ => _.Isbn == isbn);
        }

        public PublisherModel PublisherById(int id)
        {
            return _publisher.First(_ => _.Id == id);
        }
    }
}