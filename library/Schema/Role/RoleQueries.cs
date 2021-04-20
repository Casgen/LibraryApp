using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Role
{
    public class RoleQueries
    {
        public async Task<RoleModel> GetRole(int id, [ScopedService] LibraryDbContext context)
        {
            RoleModel publisher = await context.Roles.FindAsync(id);
            return publisher;
        }
        public async Task<List<RoleModel>> GetRoles([ScopedService] LibraryDbContext context)
        {
            List<RoleModel> publishers = await context.Roles.ToListAsync();
            return publishers;
        }
    }
}
