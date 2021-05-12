using DataLayer;
using HotChocolate.Types;
using Library.Schema.Author;
using Library.Schema.Book;
using Library.Schema.Category;
using Library.Schema.Image;
using Library.Schema.Magazine;
using Library.Schema.Publication;
using Library.Schema.Publisher;
using Library.Schema.Reservation;
using Library.Schema.Review;
using Library.Schema.Role;
using Library.Schema.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema
{
    public class RootQuery : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            // Author Queires
            descriptor.Field<AuthorQueries>(x => x.GetAuthor(default, default)).UseDbContext<LibraryDbContext>().Type<AuthorType>();
            descriptor.Field<AuthorQueries>(x => x.GetAuthors(default)).UseDbContext<LibraryDbContext>().Type<ListType<AuthorType>>();

            //// Book Queries
            descriptor.Field<BookQueries>(x => x.GetBook(default, default)).UseDbContext<LibraryDbContext>().Type<BookType>();
            descriptor.Field<BookQueries>(x => x.GetBooks(default)).UseDbContext<LibraryDbContext>().Type<ListType<BookType>>().UseFiltering();

            // Category Queires
            descriptor.Field<CategoryQueries>(x => x.GetCategory(default, default)).UseDbContext<LibraryDbContext>().Type<CategoryType>();
            descriptor.Field<CategoryQueries>(x => x.GetCategories(default)).UseDbContext<LibraryDbContext>().Type<ListType<CategoryType>>();

            // Image Queires
            descriptor.Field<ImageQueries>(x => x.GetImage(default, default)).UseDbContext<LibraryDbContext>().Type<ImageType>();
            descriptor.Field<ImageQueries>(x => x.GetImages(default)).UseDbContext<LibraryDbContext>().Type<ListType<ImageType>>();

            // Magazine Queires
            descriptor.Field<MagazineQueries>(x => x.GetMagazine(default, default)).UseDbContext<LibraryDbContext>().Type<MagazineType>();
            descriptor.Field<MagazineQueries>(x => x.GetMagazines(default)).UseDbContext<LibraryDbContext>().Type<ListType<MagazineType>>();

            // Publication Queires
            descriptor.Field<PublicationQueries>(x => x.GetPublication(default, default)).UseDbContext<LibraryDbContext>().Type<PublicationType>();
            descriptor.Field<PublicationQueries>(x => x.GetPublications(default)).UseDbContext<LibraryDbContext>().Type<ListType<PublicationType>>().UseFiltering();

            // Publisher Queires
            descriptor.Field<PublisherQueries>(x => x.GetPublisher(default, default)).UseDbContext<LibraryDbContext>().Type<PublisherType>();
            descriptor.Field<PublisherQueries>(x => x.GetPublishers(default)).UseDbContext<LibraryDbContext>().Type<ListType<PublisherType>>();

            // Reservation Queires
            descriptor.Field<ReservationQueries>(x => x.GetReservation(default, default)).UseDbContext<LibraryDbContext>().Type<ReservationType>();
            descriptor.Field<ReservationQueries>(x => x.GetReservations(default)).UseDbContext<LibraryDbContext>().Type<ListType<ReservationType>>();

            // Review Queires
            descriptor.Field<ReviewQueries>(x => x.GetReview(default, default)).UseDbContext<LibraryDbContext>().Type<ReviewType>();
            descriptor.Field<ReviewQueries>(x => x.GetReviews(default)).UseDbContext<LibraryDbContext>().Type<ListType<ReviewType>>();

            // Role Queires
            //descriptor.Field<RoleQueries>(x => x.GetRole(default, default)).UseDbContext<LibraryDbContext>().Type<RoleType>();
            //descriptor.Field<RoleQueries>(x => x.GetRoles(default)).UseDbContext<LibraryDbContext>().Type<ListType<RoleType>>();

            // User Queires
            descriptor.Field<UserQueries>(x => x.GetUser(default, default)).UseDbContext<LibraryDbContext>().Type<UserType>();
            descriptor.Field<UserQueries>(x => x.GetUsers(default)).UseDbContext<LibraryDbContext>().Type<ListType<UserType>>();
        }
    }
}
