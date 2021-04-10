using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class AuthorRepository : Repository<AuthorModel>
    {
        public AuthorRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }

    }
}
