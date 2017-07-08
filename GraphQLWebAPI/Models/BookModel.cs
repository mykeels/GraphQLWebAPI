using GraphQLWebAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraphQLWebAPI.Models
{
    public class BookModel
    {
        public string Isbn { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public AuthorModel Author { get; set; } = new AuthorModel { };

        [Required]
        public PublisherModel Publisher { get; set; } = new PublisherModel { };

        private static string[] names = new string[] { "Freddy", "James", "David", "John", "Peter", "Paul" };
        private static string[] books = new string[] { "A tale of two cities", "Peter's Hand", "The Cryptic Message", "The Messenger", "The law suit", "Music for Kids" };
        private static string[] publishers = new string[] { "Macmillan", "Kevins", "Holy Prints" };


        public static IEnumerable<BookModel> GetBooks(int count)
        {
            foreach (int id in Enumerable.Range(1, count))
            {
                yield return new BookModel()
                {
                    Author = new AuthorModel()
                    {
                        Id = id,
                        Name = names[Convert.ToInt32(Math.Floor(Number.Rnd() * names.Length))] + " " + names[Convert.ToInt32(Math.Floor(Number.Rnd() * names.Length))],
                        Birthdate = DateTime.Now.AddYears(Convert.ToInt32(Math.Floor(Number.Rnd() * 20)))
                    },
                    Isbn = Guid.NewGuid().ToString(),
                    Name = books[Convert.ToInt32(Math.Floor(Number.Rnd() * books.Length))],
                    Publisher = new PublisherModel()
                    {
                        Id = id,
                        Name = publishers[Convert.ToInt32(Math.Floor(Number.Rnd() * publishers.Length))]
                    }
                };
            }
        }
    }
}