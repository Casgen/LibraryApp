using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PublisherRepository : Repository<PublisherModel>
    {
        public PublisherRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
