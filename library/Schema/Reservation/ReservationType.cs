using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Reservation
{
    public class ReservationType : ObjectType<ReservationModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ReservationModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }
    }
}
