using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    [ExtendObjectType("MutationQuery")]
    public class ImageMutations
    {
        private readonly ImageRepository imageRepository;

        public ImageMutations(ImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<ImageModel> CreateBook(ImageModel imageModel)
        {
            await imageRepository.CreateAsync(imageModel);
            return imageModel;
        }
    }
}
