using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Publication
{
    public class PublicationInputType : InputObjectType<PublicationModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PublicationModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
        }
    }
}
