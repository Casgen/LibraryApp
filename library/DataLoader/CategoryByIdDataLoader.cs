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
    public class CategoryByIdDataLoader : BatchDataLoader<int, CategoryModel>
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public CategoryByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryDbContext> dbContextFactory) : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<int, CategoryModel>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using LibraryDbContext context = dbContextFactory.CreateDbContext();

            return await context.Categories.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
        }
    }
}
