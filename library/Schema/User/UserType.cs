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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.User
{
    public class UserType : ObjectType<UserModel>
    {
        protected override void Configure(IObjectTypeDescriptor<UserModel> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();

            descriptor.Field(x => x.Role).ResolveWith<UserResolvers>(x => x.GetRole(default, default, default, default));
            descriptor.Field(x => x.Reviews).ResolveWith<UserResolvers>(x => x.GetReviews(default, default, default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field(x => x.Reservations).ResolveWith<UserResolvers>(x => x.GetReservations(default, default,default, default)).UseDbContext<LibraryDbContext>();
        }

        private class UserResolvers
        {
            public async Task<IdentityRole> GetRole(UserModel userModel, RoleByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                string roleId = context.UserRoles
                    .Where(x => x.UserId == userModel.Id)
                    .Select(x => x.RoleId)
                    .FirstOrDefault();

                return await dataLoader.LoadAsync(roleId, cancellationToken);
            }
            public async Task<IReadOnlyList<ReviewModel>> GetReviews(UserModel userModel, ReviewByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] reviewIds = await context.Reviews
                    .Where(x => x.UserId == userModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(reviewIds, cancellationToken);
            }
            public async Task<IReadOnlyList<ReservationModel>> GetReservations(UserModel userModel, ReservationByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] reservationIds = await context.Reservations
                    .Where(x => x.UserId == userModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(reservationIds, cancellationToken);
            }
        }
    }
}