﻿using HotChocolate.Types;
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
            descriptor.Field<AuthorMutations>(x => x.CreateAuthor(default)).Argument("authorModel", x=>x.Type<AuthorInputType>());

            // Book Mutations
            descriptor.Field<BookMutations>(x => x.CreateBook(default)).Argument("bookModel", x => x.Type<BookInputType>());

            // Category Mutations
            descriptor.Field<CategoryMutations>(x => x.CreateCategory(default)).Argument("categoryModel", x => x.Type<CategoryInputType>());

            // Image Mutations
            descriptor.Field<ImageMutations>(x => x.CreateImage(default)).Argument("imageModel", x => x.Type<ImageInputType>());

            // Magazine Mutations
            descriptor.Field<MagazineMutations>(x => x.CreateMagazine(default)).Argument("magazineModel", x => x.Type<MagazineInputType>());

            // Publication Mutations
            descriptor.Field<PublicationMutations>(x => x.CreatePublication(default)).Argument("publicationModel", x => x.Type<PublicationInputType>());

            // Publisher Mutations
            descriptor.Field<PublisherMutations>(x => x.CreatePublisher(default)).Argument("publisherModel", x => x.Type<PublisherInputType>());

            // Reservation Mutations
            descriptor.Field<ReservationMutations>(x => x.CreateReservation(default)).Argument("reservationModel", x => x.Type<ReservationInputType>());

            // Review Mutations
            descriptor.Field<ReviewMutations>(x => x.CreateReview(default)).Argument("reviewModel", x => x.Type<ReviewInputType>());

            // Role Mutations
            descriptor.Field<RoleMutations>(x => x.CreateRole(default)).Argument("roleModel", x => x.Type<RoleInputType>());

            // User Mutations
            descriptor.Field<UserMutations>(x => x.CreateUser(default)).Argument("userModel", x => x.Type<UserInputType>());
        }
    }
}