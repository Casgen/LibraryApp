using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Publication
{
    public class PublicationMutations
    {
        public async Task<PublicationModel> CreatePublication(PublicationModel publicationModel, [ScopedService] LibraryDbContext context)
        {
            await context.Publications.AddAsync(publicationModel);
            await context.SaveChangesAsync();
            return publicationModel;
        }

        public async Task<PublicationModel> DeletePublication(int id, [ScopedService] LibraryDbContext context)
        {
            PublicationModel publicationModel = await context.Publications.FindAsync(id);
            context.Publications.Remove(publicationModel);
            await context.SaveChangesAsync();
            return publicationModel;
        }

    }
}
