using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    public class ImageMutations
    {
        public async Task<ImageModel> CreateImage(ImageModel imageModel, [ScopedService] LibraryDbContext context)
        {
            await context.Images.AddAsync(imageModel);
            await context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<ImageModel> DeleteImage(int id, [ScopedService] LibraryDbContext context)
        {
            ImageModel imageModel = await context.Images.FindAsync(id);
            context.Images.Remove(imageModel);
            await context.SaveChangesAsync();
            return imageModel;
        }
    }
}
