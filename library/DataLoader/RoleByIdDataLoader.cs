using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.DataLoader
{
    public class RoleByIdDataLoader : BatchDataLoader<string, IdentityRole>
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public RoleByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryDbContext> dbContextFactory) : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<string, IdentityRole>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            await using LibraryDbContext context = dbContextFactory.CreateDbContext();

            return (IReadOnlyDictionary<string, IdentityRole>)await context.UserRoles.Where(x => keys.Contains(x.RoleId)).ToDictionaryAsync(x => x.RoleId);
        }
    }
}
