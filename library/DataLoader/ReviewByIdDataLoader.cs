using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.DataLoader
{
    public class ReviewByIdDataLoader : BatchDataLoader<int, ReviewModel>
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public ReviewByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryDbContext> dbContextFactory) : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<int, ReviewModel>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using LibraryDbContext context = dbContextFactory.CreateDbContext();

            return await context.Reviews.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
        }
    }
}
