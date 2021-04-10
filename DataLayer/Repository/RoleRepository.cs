using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repository
{
    public class RoleRepository : Repository<RoleModel>
    {
        public RoleRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
