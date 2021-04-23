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

namespace Library.Schema.Magazine
{
    public class MagazineType : ObjectType<MagazineModel>
    {
        protected override void Configure(IObjectTypeDescriptor<MagazineModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(x => x.Publication).ResolveWith<MagazineResolvers>(x => x.GetPublication(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class MagazineResolvers
        {
            public async Task<PublicationModel> GetPublication(MagazineModel magazineModel,[ScopedService] LibraryDbContext context,PublicationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                int publicationId = context.Publications
                    .Where(x => x.MagazineId == magazineModel.Id)
                    .Select(x=>x.Id)
                    .FirstOrDefault();

                return await dataLoader.LoadAsync(publicationId, cancellationToken);
            }
        }
    }
}
