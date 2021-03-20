using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Publication
    {
        public string Name {get; set; }
        public int YearOfPub { get; set; }
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public int ImageID { get; set; }
        public string Text { get; set; }

    }
}
