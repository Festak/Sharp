using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}