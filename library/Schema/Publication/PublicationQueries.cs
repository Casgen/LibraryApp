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

namespace Library.Schema.Publication
{
    public class PublicationQueries
    {
        public async Task<PublicationModel> GetPublication(int id, [ScopedService] LibraryDbContext context)
        {
            PublicationModel publication = await context.Publications.FindAsync(id);
            return publication;
        }

        public async Task<List<PublicationModel>> GetPublications([ScopedService] LibraryDbContext context)
        {
            List<PublicationModel> publications = await context.Publications.ToListAsync();
            return publications;
        }

    }
}
