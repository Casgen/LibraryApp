using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Role
{
    public class RoleMutations
    {

        public async Task<RoleModel> CreateRole(RoleModel roleModel, [ScopedService] LibraryDbContext context)
        {
            await context.Roles.AddAsync(roleModel);
            await context.SaveChangesAsync();
            return roleModel;
        }
        public async Task<RoleModel> DeleteRole(int id, [ScopedService] LibraryDbContext context)
        {
            RoleModel roleModel = await context.Roles.FindAsync(id);
            context.Roles.Remove(roleModel);
            await context.SaveChangesAsync();
            return roleModel;
        }
    }
}
