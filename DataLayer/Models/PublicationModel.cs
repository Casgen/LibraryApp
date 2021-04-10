using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class PublicationModel
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
        public int BookId { get; set; }
        public int MagazineId { get; set; }
        public virtual BookModel Book { get; set; }
        public virtual MagazineModel Magazine { get; set; }
        public virtual ImageModel Image { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<ReservationModel> Reservation { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
    }
}
