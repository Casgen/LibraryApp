using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }
        public int? PublicationId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        
        public virtual PublicationModel Publication { get; set; }
    }
}
