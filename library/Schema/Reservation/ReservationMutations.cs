using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Reservation
{
    [ExtendObjectType("MutationQuery")]
    public class ReservationMutations
    {
        private readonly ReservationRepository reservationRepository;

        public ReservationMutations(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task<ReservationModel> CreateReservation(ReservationModel reservationModel)
        {
            await reservationRepository.CreateAsync(reservationModel);
            return reservationModel;
        }

        public async Task<ReservationModel> DeleteReservation(int id)
        {
            return await reservationRepository.DeleteAsync(id);
        }
    }
}
