using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Role
{
    public class RoleType : ObjectType<RoleModel>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }
    }
}
