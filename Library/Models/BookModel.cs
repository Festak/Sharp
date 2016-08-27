using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }


        public virtual string Name { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual string Description { get; set; }
      //  public virtual Offer Offer { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual byte[] CurrentBook { get; set; }


    }
}