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

namespace Library.Schema.Category
{
    public class CategoryType : ObjectType<CategoryModel>
    {
        protected override void Configure(IObjectTypeDescriptor<CategoryModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Name).Type<StringType>();

            descriptor.Field(x => x.Publications).ResolveWith<CategoryResolvers>(x => x.GetPublications(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class CategoryResolvers
        {
            public async Task<IReadOnlyList<PublicationModel>> GetPublications(CategoryModel categoryModel, PublicationByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] publicationIds = await context.Publications
                    .Where(x => x.CategoryId == categoryModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(publicationIds, cancellationToken);
            }
        }
    }
}
