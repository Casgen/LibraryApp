using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Jobs;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Quartz;

namespace Library.Schema.Reservation
{
    public class ReservationMutations
    {
        private readonly IScheduler scheduler;

        public ReservationMutations(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public async Task<ReservationModel> CreateReservation(ReservationModel reservationModel, [ScopedService] LibraryDbContext context)
        {
            await context.Reservations.AddAsync(reservationModel);
            await context.SaveChangesAsync();

            IJobDetail job = JobBuilder.Create<DebtUpdateJob>()
                .UsingJobData("reservationId",reservationModel.Id)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartAt((DateTime.UtcNow.AddSeconds(60)))
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            return reservationModel;
        }

        public async Task<ReservationModel> DeleteReservation(int id, [ScopedService] LibraryDbContext context)
        {
            ReservationModel reservationModel = await context.Reservations.FindAsync(id);
            context.Reservations.Remove(reservationModel);
            await context.SaveChangesAsync();
            return reservationModel;
        }

        public async Task<ReservationModel> UpdateReservation(ReservationModel reservationModel, [ScopedService] LibraryDbContext context)
        {
            context.Reservations.Update(reservationModel);
            await context.SaveChangesAsync();
            return reservationModel;
        }
    }
}
