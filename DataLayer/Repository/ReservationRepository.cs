using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repository
{
    public class ReservationRepository : Repository<ReservationModel>
    {
        public ReservationRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
