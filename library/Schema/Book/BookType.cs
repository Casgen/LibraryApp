using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
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
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }

        private class BookResolvers
        {
            public async Task<AuthorModel> GetAuthor(BookModel bookModel, AuthorByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(bookModel.AuthorId, cancellationToken);
            }
        }

    }
}
