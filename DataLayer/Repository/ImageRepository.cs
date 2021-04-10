using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class ImageRepository : Repository<ImageModel>
    {
        public ImageRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
