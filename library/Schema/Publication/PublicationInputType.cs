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
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.Book).Ignore();
            descriptor.Field(b => b.BookId).Ignore();
            descriptor.Field(b => b.Reservation).Ignore();
            descriptor.Field(b => b.Category).Ignore();
            descriptor.Field(b => b.Magazine).Ignore();
            descriptor.Field(b => b.MagazineId).Ignore();
            descriptor.Field(b => b.Publisher).Ignore();
        }
    }
}
