using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Publication
    {
        public int Id { get; set; }
        [Required]
        public string Name {get; set; }
        [Required]
        public int YearOfPub { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ImageId { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual Image Image { get; set; }

    }
}
