using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Publisher
{
    public class PublisherMutations
    {
        public async Task<PublisherModel> CreatePublisher(PublisherModel publisherModel, [ScopedService] LibraryDbContext context)
        {
            await context.Publishers.AddAsync(publisherModel);
            await context.SaveChangesAsync();
            return publisherModel;
        }

        public async Task<PublisherModel> DeletePublisher(int id, [ScopedService] LibraryDbContext context)
        {
            PublisherModel publisherModel = await context.Publishers.FindAsync(id);
            context.Publishers.Remove(publisherModel);
            await context.SaveChangesAsync();
            return publisherModel;
        }

        public async Task<PublisherModel> UpdatePublisher(PublisherModel publisherModel, [ScopedService] LibraryDbContext context)
        {
            context.Publishers.Update(publisherModel);
            await context.SaveChangesAsync();
            return publisherModel;
        }
    }
}
