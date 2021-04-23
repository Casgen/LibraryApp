using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string SecondName { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
}
