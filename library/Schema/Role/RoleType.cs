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

namespace Library.Schema.Role
{
    public class RoleType : ObjectType<RoleModel>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Users).ResolveWith<RoleResolvers>(x => x.GetUsers(default, default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class RoleResolvers
        {
            public async Task<IReadOnlyList<UserModel>> GetUsers(RoleModel roleModel, UserByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] roleIds = await context.Users
                    .Where(x => x.RoleId == roleModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(roleIds, cancellationToken);
            }
        }
    }
}
