using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.User
{
    public class UserQueries
    {
        public async Task<UserModel> GetUser(int id, [ScopedService] LibraryDbContext context)
        {
            UserModel publisher = await context.Users.FindAsync(id);
            return publisher;
        }
        public async Task<List<UserModel>> GetUsers([ScopedService] LibraryDbContext context)
        {
            List<UserModel> publishers = await context.Users.ToListAsync();
            return publishers;
        }
    }
}
