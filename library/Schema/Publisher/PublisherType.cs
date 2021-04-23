using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Library.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Publisher
{
    public class PublisherType : ObjectType<PublisherModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PublisherModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(x => x.Publications).ResolveWith<PublisherResolvers>(x => x.GetPublications(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class PublisherResolvers
        {
            public async Task<IReadOnlyList<PublicationModel>> GetPublications(PublisherModel publisherModel, PublicationByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] publicationIds = await context.Publications
                    .Where(x => x.PublisherId == publisherModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(publicationIds, cancellationToken);
            }
        }
    }
}
