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

namespace Library.Schema.Author
{
    public class AuthorType : ObjectType<AuthorModel>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthorModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(x => x.Books).ResolveWith<AuthorResolvers>(x => x.GetBooks(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class AuthorResolvers
        {
            public async Task<IReadOnlyList<BookModel>> GetBooks(AuthorModel authorModel, BookByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] bookIds = await context.Books
                    .Where(x => x.AuthorId == authorModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(bookIds, cancellationToken);
            }
        }
    }
}
