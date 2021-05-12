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
            descriptor.Field(b => b.Role).Ignore();
            descriptor.Field(b => b.Reviews).Ignore();
        }
    }
}
