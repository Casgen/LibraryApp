using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
