using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Magazine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Issue { get; set; }
        [Required]
        public int PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
