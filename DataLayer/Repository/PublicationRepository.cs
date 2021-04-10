using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class PublicationRepository : Repository<PublicationModel>
    {
        public PublicationRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
