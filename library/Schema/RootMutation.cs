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
    public class RootMutation : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            // Author Mutations
            descriptor.Field<AuthorMutations>(x => x.CreateAuthor(default, default)).UseDbContext<LibraryDbContext>().Argument("authorModel", x => x.Type<AuthorInputType>());
            descriptor.Field<AuthorMutations>(x => x.DeleteAuthor(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<AuthorMutations>(x => x.UpdateAuthor(default, default)).UseDbContext<LibraryDbContext>().Argument("authorModel", x => x.Type<AuthorInputType>());

            // Book Mutations
            descriptor.Field<BookMutations>(x => x.CreateBook(default, default)).UseDbContext<LibraryDbContext>().Argument("bookModel", x => x.Type<BookInputType>());
            descriptor.Field<BookMutations>(x => x.DeleteBook(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<BookMutations>(x => x.UpdateBook(default, default)).UseDbContext<LibraryDbContext>().Argument("bookModel", x => x.Type<BookInputType>());

            // Category Mutations
            descriptor.Field<CategoryMutations>(x => x.CreateCategory(default, default)).UseDbContext<LibraryDbContext>().Argument("categoryModel", x => x.Type<CategoryInputType>());
            descriptor.Field<CategoryMutations>(x => x.DeleteCategory(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<CategoryMutations>(x => x.UpdateCategory(default, default)).UseDbContext<LibraryDbContext>().Argument("categoryModel", x => x.Type<CategoryInputType>());

            // Image Mutations
            descriptor.Field<ImageMutations>(x => x.CreateImage(default, default)).UseDbContext<LibraryDbContext>().Argument("imageModel", x => x.Type<ImageInputType>());
            descriptor.Field<ImageMutations>(x => x.DeleteImage(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<ImageMutations>(x => x.UpdateImage(default, default)).UseDbContext<LibraryDbContext>().Argument("imageModel", x => x.Type<ImageInputType>());

            // Magazine Mutations
            descriptor.Field<MagazineMutations>(x => x.CreateMagazine(default, default)).UseDbContext<LibraryDbContext>().Argument("magazineModel", x => x.Type<MagazineInputType>());
            descriptor.Field<MagazineMutations>(x => x.DeleteMagazine(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<MagazineMutations>(x => x.UpdateMagazine(default, default)).UseDbContext<LibraryDbContext>().Argument("magazineModel", x => x.Type<MagazineInputType>());

            // Publication Mutations
            //descriptor.Field<PublicationMutations>(x => x.CreatePublication(default, default)).UseDbContext<LibraryDbContext>().Argument("publicationModel", x => x.Type<PublicationInputType>());
            descriptor.Field<PublicationMutations>(x => x.DeletePublication(default, default)).UseDbContext<LibraryDbContext>().Argument("publicationModel", x => x.Type<PublicationInputType>());
            descriptor.Field<PublicationMutations>(x => x.UpdatePublication(default, default)).UseDbContext<LibraryDbContext>().Argument("publicationModel", x => x.Type<PublicationInputType>());

            // Publisher Mutations
            descriptor.Field<PublisherMutations>(x => x.CreatePublisher(default, default)).UseDbContext<LibraryDbContext>().Argument("publisherModel", x => x.Type<PublisherInputType>());//.Authorize(new[] {"ADMIN"});
            descriptor.Field<PublisherMutations>(x => x.DeletePublisher(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<PublisherMutations>(x => x.UpdatePublisher(default, default)).UseDbContext<LibraryDbContext>().Argument("publisherModel", x => x.Type<PublisherInputType>());//.Authorize(new[] {"Admin"});

            // Reservation Mutations
            descriptor.Field<ReservationMutations>(x => x.CreateReservation(default, default)).UseDbContext<LibraryDbContext>().Argument("reservationModel", x => x.Type<ReservationInputType>());
            descriptor.Field<ReservationMutations>(x => x.DeleteReservation(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<ReservationMutations>(x => x.UpdateReservation(default, default)).UseDbContext<LibraryDbContext>().Argument("reservationModel", x => x.Type<ReservationInputType>());

            // Review Mutations
            descriptor.Field<ReviewMutations>(x => x.CreateReview(default, default)).UseDbContext<LibraryDbContext>().Argument("reviewModel", x => x.Type<ReviewInputType>());
            descriptor.Field<ReviewMutations>(x => x.DeleteReview(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<ReviewMutations>(x => x.UpdateReview(default, default)).UseDbContext<LibraryDbContext>().Argument("reviewModel", x => x.Type<ReviewInputType>());

            // Role Mutations
            //descriptor.Field<RoleMutations>(x => x.CreateRole(default, default)).UseDbContext<LibraryDbContext>().Argument("roleModel", x => x.Type<RoleInputType>());
            //descriptor.Field<RoleMutations>(x => x.DeleteRole(default, default)).UseDbContext<LibraryDbContext>();
            //descriptor.Field<RoleMutations>(x => x.UpdateRole(default, default)).UseDbContext<LibraryDbContext>().Argument("roleModel", x => x.Type<RoleInputType>());

            // User Mutations
            descriptor.Field<UserMutations>(x => x.Register(default, default, default)).Argument("userModel", x => x.Type<UserInputType>());
            descriptor.Field<UserMutations>(x => x.Login(default, default, default, default)).UseDbContext<LibraryDbContext>().Argument("userModel", x => x.Type<UserInputType>());
            descriptor.Field<UserMutations>(x => x.Logout(default));
            descriptor.Field<UserMutations>(x => x.DeleteUser(default, default)).UseDbContext<LibraryDbContext>();
            descriptor.Field<UserMutations>(x => x.UpdateUser(default, default)).UseDbContext<LibraryDbContext>().Argument("userModel", x => x.Type<UserInputType>());
        }
    }
}
