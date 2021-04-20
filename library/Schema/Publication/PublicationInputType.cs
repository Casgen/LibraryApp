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
            descriptor.Field(b => b.Book).Ignore();
            descriptor.Field(b => b.Reservation).Ignore();
            descriptor.Field(b => b.Category).Ignore();
            descriptor.Field(b => b.Image).Ignore();
            descriptor.Field(b => b.Magazine).Ignore();
        }
    }
}
