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
            // Publisher Queires
            descriptor.Field<AuthorQueries>(x => x.GetAuthor(default)).Type<AuthorType>();
            descriptor.Field<AuthorQueries>(x => x.GetAuthors()).Type<ListType<AuthorType>>();

            // Book Queries
            descriptor.Field<BookQueries>(x => x.GetBook(default)).Type<BookType>();
            descriptor.Field<BookQueries>(x => x.GetBooks()).Type<ListType<BookType>>();

            // Category Queires
            descriptor.Field<CategoryQueries>(x => x.GetCategory(default)).Type<CategoryType>();
            descriptor.Field<CategoryQueries>(x => x.GetCategories()).Type<ListType<CategoryType>>();

            // Image Queires
            descriptor.Field<ImageQueries>(x => x.GetImage(default)).Type<ImageType>();
            descriptor.Field<ImageQueries>(x => x.GetImages()).Type<ListType<ImageType>>();

            // Magazine Queires
            descriptor.Field<MagazineQueries>(x => x.GetMagazine(default)).Type<MagazineType>();
            descriptor.Field<MagazineQueries>(x => x.GetMagazines()).Type<ListType<MagazineType>>();

            // Publication Queires
            descriptor.Field<PublicationQueries>(x => x.GetPublication(default)).Type<PublicationType>();
            descriptor.Field<PublicationQueries>(x => x.GetPublications()).Type<ListType<PublicationType>>();

            // Publisher Queires
            descriptor.Field<PublisherQueries>(x => x.GetPublisher(default)).Type<PublisherType>();
            descriptor.Field<PublisherQueries>(x => x.GetPublishers()).Type<ListType<PublisherType>>();

            // Reservation Queires
            descriptor.Field<ReservationQueries>(x => x.GetReservation(default)).Type<ReservationType>();
            descriptor.Field<ReservationQueries>(x => x.GetReservations()).Type<ListType<ReservationType>>();

            // Review Queires
            descriptor.Field<ReviewQueries>(x => x.GetReview(default)).Type<ReviewType>();
            descriptor.Field<ReviewQueries>(x => x.GetReviews()).Type<ListType<ReviewType>>();

            // Role Queires
            descriptor.Field<RoleQueries>(x => x.GetRole(default)).Type<RoleType>();
            descriptor.Field<RoleQueries>(x => x.GetRoles()).Type<ListType<RoleType>>();

            // User Queires
            descriptor.Field<UserQueries>(x => x.GetUser(default)).Type<UserType>();
            descriptor.Field<UserQueries>(x => x.GetUsers()).Type<ListType<UserType>>();
        }
    }
}
