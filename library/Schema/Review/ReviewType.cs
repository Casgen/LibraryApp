using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Library.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Review
{
    public class ReviewType : ObjectType<ReviewModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ReviewModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(x => x.Publication).ResolveWith<ReviewResolvers>(x => x.GetPublication(default, default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field(x => x.User).ResolveWith<ReviewResolvers>(x => x.GetUser(default, default, default)).UseDbContext<LibraryDbContext>();
        }

        private class ReviewResolvers
        {
            public async Task<PublicationModel> GetPublication(ReviewModel reviewModel, PublicationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(reviewModel.PublicationId, cancellationToken);
            }

            public async Task<UserModel> GetUser(ReviewModel reviewModel, UserByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(reviewModel.UserId, cancellationToken);
            }
        }
    }
}
