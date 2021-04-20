using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Magazine
{
    public class MagazineQueries
    {
        public async Task<MagazineModel> GetMagazine(int id, [ScopedService] LibraryDbContext context)
        {
            MagazineModel magazine = await context.Magazines.FindAsync(id);
            return magazine;
        }

        public async Task<List<MagazineModel>> GetMagazines([ScopedService] LibraryDbContext context)
        {
            List<MagazineModel> magazines = await context.Magazines.ToListAsync();
            return magazines;
        }
    }
}
