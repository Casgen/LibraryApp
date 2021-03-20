using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public bool Depublication { get; set; }
        [Required]
        [StringLength(1024)]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PublicationId { get; set; }

        public virtual User User { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
