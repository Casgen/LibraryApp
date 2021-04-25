using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(17)]
        public string ISBN { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public virtual AuthorModel Author { get; set; }
        public virtual PublicationModel Publication { get; set; }
    }
}
