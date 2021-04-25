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

namespace Library.Schema.Publication
{
    public class PublicationType : ObjectType<PublicationModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PublicationModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();

            descriptor.Field(b => b.Image).ResolveWith<PublicationResolvers>(b => b.GetImage(default, default, default));
            descriptor.Field(b => b.Category).ResolveWith<PublicationResolvers>(b => b.GetCategory(default, default, default));
            descriptor.Field(b => b.Magazine).ResolveWith<PublicationResolvers>(b => b.GetMagazine(default, default, default));
            descriptor.Field(b => b.Book).ResolveWith<PublicationResolvers>(b => b.GetBook(default, default, default));
            descriptor.Field(b => b.Reviews).ResolveWith<PublicationResolvers>(b => b.GetReviews(default, default, default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field(b => b.Publisher).ResolveWith<PublicationResolvers>(b => b.GetPublisher(default, default, default));
            descriptor.Field(b => b.Reservation).ResolveWith<PublicationResolvers>(b => b.GetReservation(default, default, default,default)).UseDbContext<LibraryDbContext>(); ;
        }

        private class PublicationResolvers
        {
            public async Task<PublisherModel> GetPublisher(PublicationModel publicationModel, PublisherByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(publicationModel.PublisherId, cancellationToken);
            }
            public async Task<ReservationModel> GetReservation(PublicationModel publicationModel,[ScopedService] LibraryDbContext context, ReservationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                int reservationId = context.Reservations
                    .Where(x => x.PublicationId == publicationModel.Id)
                    .Select(x => x.Id)
                    .FirstOrDefault();

                return await dataLoader.LoadAsync(reservationId, cancellationToken);
            }
            public async Task<ImageModel> GetImage(PublicationModel publicationModel, ImageByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync((int) publicationModel.ImageId, cancellationToken);
            }

            public async Task<CategoryModel> GetCategory(PublicationModel publicationModel, CategoryByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return await dataLoader.LoadAsync(publicationModel.CategoryId, cancellationToken);
            }

            public async Task<BookModel> GetBook(PublicationModel publicationModel, BookByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                if (publicationModel.BookId != null) return await dataLoader.LoadAsync((int)publicationModel.BookId, cancellationToken);
                return null;
            }

            public async Task<MagazineModel> GetMagazine(PublicationModel publicationModel, MagazineByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                if (publicationModel.BookId != null) return await dataLoader.LoadAsync((int)publicationModel.MagazineId, cancellationToken);
                return null;
            }

            public async Task<IReadOnlyList<ReviewModel>> GetReviews(PublicationModel publicationModel, ReviewByIdDataLoader dataLoader, [ScopedService] LibraryDbContext context, CancellationToken cancellationToken)
            {
                int[] reviewIds = await context.Reviews
                    .Where(x => x.PublicationId ==publicationModel.Id)
                    .Select(x => x.Id)
                    .ToArrayAsync();

                return await dataLoader.LoadAsync(reviewIds, cancellationToken);
            }
        }
    }
}
