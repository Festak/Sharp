using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int PriceId { get; set; }
        public virtual Price Price { get; set; }
        public byte[] Image { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }

    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
    public class Price
    {
        public int PriceId { get; set; }
        public string PriceName { get; set; }
        public decimal PriceCourse { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}