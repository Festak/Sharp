using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public virtual string Title { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Book Book { get; set; }
        public virtual double? Rating { get; set; }
        public virtual bool IsAccepted { get; set; }

    }
}