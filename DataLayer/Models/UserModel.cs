using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(9)]
        public string TelNumber { get; set; }
        [Required]
        public int RoleId { get; set; }

        public virtual RoleModel Role { get; set; }
        public virtual ICollection<ReservationModel> Reservations { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
    }
}
