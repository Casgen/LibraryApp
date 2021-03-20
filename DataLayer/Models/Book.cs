using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required]
        [StringLength(17)]
        public string ISBN { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
        public virtual Author Author { get; set; }

    }
}
