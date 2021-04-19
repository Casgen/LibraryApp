using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Review
{
    [ExtendObjectType("MutationQuery")]
    public class ReviewMutations
    {
        private readonly ReviewRepository reviewRepository;

        public ReviewMutations(ReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<ReviewModel> CreateReview(ReviewModel reviewModel)
        {
            await reviewRepository.CreateAsync(reviewModel);
            return reviewModel;
        }
        public async Task<ReviewModel> DeleteReview(int id)
        {
            return await reviewRepository.DeleteAsync(id);
        }
    }
}
