using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Publisher
{
    public class PublisherType : ObjectType<PublisherModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PublisherModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }
    }
}
