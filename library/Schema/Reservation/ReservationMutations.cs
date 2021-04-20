using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Reservation
{
    public class ReservationMutations
    {
        public async Task<ReservationModel> CreateReservation(ReservationModel reservationModel, [ScopedService] LibraryDbContext context)
        {
            await context.Reservations.AddAsync(reservationModel);
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
