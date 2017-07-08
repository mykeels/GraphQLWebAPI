using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphQLWebAPI.Models
{
    public class PublisherModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public BookModel[] Books { get; set; } = new BookModel[] { };

        public AuthorModel[] Authors { get; set; } = new AuthorModel[] { };
    }
}