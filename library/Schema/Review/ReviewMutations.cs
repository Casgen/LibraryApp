using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Review
{
    public class ReviewMutations
    {
        public async Task<ReviewModel> CreateReview(ReviewModel reviewModel, [ScopedService] LibraryDbContext context)
        {
            await context.Reviews.AddAsync(reviewModel);
            await context.SaveChangesAsync();
            return reviewModel;
        }
        public async Task<ReviewModel> DeleteReview(int id, [ScopedService] LibraryDbContext context)
        {
            ReviewModel reviewModel = await context.Reviews.FindAsync(id);
            context.Reviews.Remove(reviewModel);
            await context.SaveChangesAsync();
            return reviewModel;
        }

        public async Task<ReviewModel> UpdateReview(ReviewModel ReviewModel, [ScopedService] LibraryDbContext context)
        {
            context.Reviews.Update(ReviewModel);
            await context.SaveChangesAsync();
            return ReviewModel;
        }
    }
}
