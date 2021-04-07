using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public int PublicationId { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual PublicationModel Publication { get; set; }
    }
}
