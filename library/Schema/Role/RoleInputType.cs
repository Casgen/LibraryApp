using DataLayer.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Role
{
    public class RoleInputType : InputObjectType<RoleModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<RoleModel> descriptor)
        {
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.Users).Ignore();
        }
    }
}
