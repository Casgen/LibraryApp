using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class MagazineRepository : Repository<MagazineModel>
    {
        public MagazineRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
