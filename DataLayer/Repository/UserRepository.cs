using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
