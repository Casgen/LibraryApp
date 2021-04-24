using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
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

        public IQueryable<PublicationModel> GetPublications([ScopedService] LibraryDbContext context)
        {
            return context.Publications;
        }

    }
}