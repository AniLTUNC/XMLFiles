using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLFiles.Models
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
    }
}