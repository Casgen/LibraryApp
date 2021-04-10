using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repository
{
    public class ReviewRepository : Repository<ReviewModel>
    {
        public ReviewRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }
    }
}
