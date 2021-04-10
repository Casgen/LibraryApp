using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Reservation
{
    [ExtendObjectType(Name = "RootQuery")]
    public class ReservationQueries
    {
        private readonly ReservationRepository reservationRepository;

        public ReservationQueries(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public async Task<ReservationModel> GetReservation(int id)
        {
            ReservationModel publisher = await reservationRepository.GetByIdAsync(id);
            return publisher;
        }
        public async Task<List<ReservationModel>> GetReservations()
        {
            List<ReservationModel> publishers = (List<ReservationModel>)await reservationRepository.GetAllAsync();
            return publishers;
        }
    }
}
