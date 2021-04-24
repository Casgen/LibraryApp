using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Library.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Reservation
{
    public class ReservationType : ObjectType<ReservationModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ReservationModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(x => x.Publication).ResolveWith<ReservationResolvers>(x => x.GetPublication(default, default, default));
            descriptor.Field(x => x.User).ResolveWith<ReservationResolvers>(x => x.GetUser(default, default, default)).UseDbContext<LibraryDbContext>();
            //descriptor.Field(x => x.Debt).ResolveWith<ReservationResolvers>(x => x.GetDebt(default));
        }

        private class ReservationResolvers
        {
            public async Task<PublicationModel> GetPublication(ReservationModel reservationModel, PublicationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(reservationModel.PublicationId, cancellationToken);
            }

            public async Task<UserModel> GetUser(ReservationModel reservationModel, UserByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(reservationModel.UserId, cancellationToken);
            }
            //public int GetDebt(ReservationModel reservationModel)
            //{
            //    var remainingDate = (int) Math.Floor(DateTime.Now.Subtract(reservationModel.DateTo).TotalDays);
            //    int debt = (int) Math.Ceiling((double) remainingDate/31) * 60;
            //    return remainingDate>0 ? debt : 0;
            //}
        }
    }
}
