using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Magazine
{
    public class MagazineMutations
    {
        public async Task<MagazineModel> CreateMagazine(MagazineModel magazineModel, [ScopedService] LibraryDbContext context)
        {
            await context.Magazines.AddAsync(magazineModel);
            await context.Publications.AddAsync(magazineModel.Publication);
            await context.SaveChangesAsync();
            return magazineModel;
        }

        public async Task<MagazineModel> DeleteMagazine(int id, [ScopedService] LibraryDbContext context)
        {
            MagazineModel magazineModel = await context.Magazines.FindAsync(id);
            context.Magazines.Remove(magazineModel);
            await context.SaveChangesAsync();
            return magazineModel;
        }

        public async Task<MagazineModel> UpdateMagazine(MagazineModel magazineModel, [ScopedService] LibraryDbContext context)
        {
            context.Magazines.Update(magazineModel);
            await context.SaveChangesAsync();
            return magazineModel;
        }
    }
}
