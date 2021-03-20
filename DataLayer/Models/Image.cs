﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
