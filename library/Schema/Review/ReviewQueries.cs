using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Review
{
    public class ReviewQueries
    {
        public async Task<ReviewModel> GetReview(int id, [ScopedService] LibraryDbContext context)
        {
            ReviewModel publisher = await context.Reviews.FindAsync(id);
            return publisher;
        }
        public async Task<List<ReviewModel>> GetReviews([ScopedService] LibraryDbContext context)
        {
            List<ReviewModel> publishers = await context.Reviews.ToListAsync();
            return publishers;
        }
    }
}
