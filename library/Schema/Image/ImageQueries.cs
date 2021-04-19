using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Image
{
    [ExtendObjectType(Name = "RootQuery")]
    public class ImageQueries
    {
        private readonly ImageRepository imageRepository;

        public ImageQueries(ImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<ImageModel> GetImage(int id)
        {
            ImageModel image = await imageRepository.GetByIdAsync(id);
            return image;
        }
        public async Task<List<ImageModel>> GetImages()
        {
            List<ImageModel> images = (List<ImageModel>) await imageRepository.GetAllAsync();
            return images;
        }
    }
}
