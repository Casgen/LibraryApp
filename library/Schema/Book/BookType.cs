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

namespace Library.Schema.Book
{
    public class BookType : ObjectType<BookModel>
    {
        protected override void Configure(IObjectTypeDescriptor<BookModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.ISBN).Type<StringType>();

            descriptor.Field(b => b.Author).ResolveWith<BookResolvers>(b => b.GetAuthor(default, default, default));
            descriptor.Field(x => x.Publication).ResolveWith<BookResolvers>(x => x.GetPublication(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class BookResolvers
        {
            public async Task<AuthorModel> GetAuthor(BookModel bookModel, AuthorByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(bookModel.AuthorId, cancellationToken);
            }
            public async Task<PublicationModel> GetPublication(BookModel bookModel, [ScopedService] LibraryDbContext context, PublicationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                int publicationId = context.Publications
                    .Where(x => x.BookId == bookModel.Id)
                    .Select(x => x.Id)
                    .FirstOrDefault();

                return await dataLoader.LoadAsync(publicationId, cancellationToken);
            }
        }
    }
}
