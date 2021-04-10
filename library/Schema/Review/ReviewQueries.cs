using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Review
{
    [ExtendObjectType(Name = "RootQuery")]
    public class ReviewQueries
    {
        private readonly ReviewRepository reviewRepository;

        public ReviewQueries(ReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public async Task<ReviewModel> GetReview(int id)
        {
            ReviewModel publisher = await reviewRepository.GetByIdAsync(id);
            return publisher;
        }
        public async Task<List<ReviewModel>> GetReviews()
        {
            List<ReviewModel> publishers = (List<ReviewModel>)await reviewRepository.GetAllAsync();
            return publishers;
        }
    }
}
