﻿using System;
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
    public class ReservationByIdDataLoader : BatchDataLoader<int, ReservationModel>
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public ReservationByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryDbContext> dbContextFactory) : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<int, ReservationModel>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using LibraryDbContext context = dbContextFactory.CreateDbContext();

            return await context.Reservations.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
        }
    }
}
