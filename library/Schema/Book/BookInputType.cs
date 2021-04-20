using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    public class BookInputType : InputObjectType<BookModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<BookModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.ISBN).Type<StringType>();
            descriptor.Field(b => b.Author).Ignore();
        }
    }
}
