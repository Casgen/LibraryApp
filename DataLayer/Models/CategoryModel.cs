using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        public virtual ICollection<PublicationModel> Publications { get; set; }
    }
}
