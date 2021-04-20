using DataLayer.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Reservation
{
    public class ReservationInputType : InputObjectType<ReservationModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReservationModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.User).Ignore();
            descriptor.Field(b => b.Publication).Ignore();
        }
    }
}
