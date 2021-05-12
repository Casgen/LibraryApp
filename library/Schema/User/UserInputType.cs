using DataLayer.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.User
{
    public class UserInputType : InputObjectType<UserModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UserModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Reservations).Ignore();
            descriptor.Field(b => b.Reviews).Ignore();
            descriptor.Field(b => b.EmailConfirmed).Ignore();
            descriptor.Field(b => b.PhoneNumberConfirmed).Ignore();
            descriptor.Field(b => b.TwoFactorEnabled).Ignore();
            descriptor.Field(b => b.LockoutEnabled).Ignore();
            descriptor.Field(b => b.AccessFailedCount).Ignore();
        }
    }
}
