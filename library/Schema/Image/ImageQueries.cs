using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Image
{
    public class ImageQueries
    {
        public async Task<ImageModel> GetImage(int id, [ScopedService] LibraryDbContext context)
        {
            ImageModel image = await context.Images.FindAsync(id);
            return image;
        }
        public async Task<List<ImageModel>> GetImages([ScopedService] LibraryDbContext context)
        {
            List<ImageModel> images = await context.Images.ToListAsync();
            return images;
        }
    }
}
