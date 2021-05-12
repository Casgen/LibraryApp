using DataLayer.Models;
using HotChocolate.Types;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Role
{
    public class RoleInputType : InputObjectType<IdentityRole>
    {
        protected override void Configure(IInputObjectTypeDescriptor<IdentityRole> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.Users).Ignore();
        }
    }
}
