using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.User
{
    public class UserType : ObjectType<UserModel>
    {
        protected override void Configure(IObjectTypeDescriptor<UserModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }
    }
}