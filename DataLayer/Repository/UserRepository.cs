using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }

        public async Task<UserModel> GetByName(string name)
        {
            return await libraryDbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(name)); 
        }
    }
}
