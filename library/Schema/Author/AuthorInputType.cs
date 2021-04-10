using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Author
{
    public class AuthorInputType : InputObjectType<AuthorModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AuthorModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
        }
    }
}
