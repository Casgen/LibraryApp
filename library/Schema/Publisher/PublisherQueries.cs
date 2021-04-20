using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Publisher
{
    public class PublisherQueries
    {
        public async Task<PublisherModel> GetPublisher(int id, [ScopedService] LibraryDbContext context)
        {
            PublisherModel publisher = await context.Publishers.FindAsync(id);
            return publisher;
        }
        public async Task<List<PublisherModel>> GetPublishers([ScopedService] LibraryDbContext context)
        {
            List<PublisherModel> publishers = await context.Publishers.ToListAsync();
            return publishers;
        }
    }
}
