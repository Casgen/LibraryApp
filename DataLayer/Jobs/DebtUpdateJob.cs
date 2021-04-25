using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Jobs
{
    public class DebtUpdateJob : IJob
    {
        private readonly IDbContextFactory<LibraryDbContext> dbContextFactory;
        public DebtUpdateJob(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await using LibraryDbContext libraryDbContext = dbContextFactory.CreateDbContext();
            var reservation = libraryDbContext.Reservations.Find(context.JobDetail.JobDataMap.Get("reservationId"));

            var remainingDate = (int)Math.Ceiling(DateTime.Now.Subtract(reservation.DateTo).TotalDays);
            int debt = (int)Math.Ceiling((double)remainingDate / 31) * 60;
            reservation.Debt = remainingDate > 0 ? debt : 0;

            libraryDbContext.Reservations.Update(reservation);
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
