using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraphQLWebAPI.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public BookModel[] Books { get; set; } = new BookModel[] { };
    }
}