using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    public class BookType : ObjectType<BookModel>
    {
        protected override void Configure(IObjectTypeDescriptor<BookModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.ISBN).Type<StringType>();
            descriptor.Field(b => b.Author).ResolveWith<BookResolvers>(b => b.GetAuthor(default));
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }

        private class BookResolvers
        {
            private readonly AuthorRepository authorRepository;

            public BookResolvers(AuthorRepository authorRepository)
            {
                this.authorRepository = authorRepository;
            }

            public async Task<AuthorModel> GetAuthor(BookModel bookModel)
            {
                return await authorRepository.GetByIdAsync(bookModel.AuthorId);
            }
        }

    }
}
