using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Quartz;

namespace Library.Schema.Reservation
{
    public class ReservationMutations
    {

        public async Task<ReservationModel> CreateReservation(ReservationModel reservationModel, [ScopedService] LibraryDbContext context)
        {
            await context.Reservations.AddAsync(reservationModel);
            await context.SaveChangesAsync();

            //scheduler.JobFactory = factory;

            //var date = reservationModel.DateTo - reservationModel.DateFrom;

            //IJobDetail job = JobBuilder.Create<DebtUpdateJob>()
            //    .WithIdentity("debtUpdateJob", "reservations")
            //    .Build();
        
            //ITrigger trigger = TriggerBuilder.Create()
            //    .StartAt((DateTime.UtcNow.AddSeconds(date.TotalSeconds-1)))
            //    .WithIdentity("debtUpdateTrigger", "reservations")
            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds((int) date.TotalSeconds).RepeatForever())
            //    .Build();

            //await scheduler.ScheduleJob(job, trigger);

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
