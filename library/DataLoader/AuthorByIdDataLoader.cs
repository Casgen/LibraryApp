using DataLayer;
using DataLayer.Models;
using GreenDonut;
using HotChocolate;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DataLoader
{
    public class AuthorByIdDataLoader : BatchDataLoader<int, AuthorModel>
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public AuthorByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryDbContext> dbContextFactory) : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<int, AuthorModel>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using LibraryDbContext context = dbContextFactory.CreateDbContext();

            return await context.Authors.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
        }
    }
}
