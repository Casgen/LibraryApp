using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Reservation
{
    public class ReservationQueries
    {
        public async Task<ReservationModel> GetReservation(int id, [ScopedService] LibraryDbContext context)
        {
            ReservationModel publisher = await context.Reservations.FindAsync(id);
            return publisher;
        }
        public async Task<List<ReservationModel>> GetReservations([ScopedService] LibraryDbContext context)
        {
            List<ReservationModel> publishers = await context.Reservations.ToListAsync();
            return publishers;
        }
    }
}
