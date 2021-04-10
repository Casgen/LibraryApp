using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Magazine
{
    public class MagazineType : ObjectType<MagazineModel>
    {
        protected override void Configure(IObjectTypeDescriptor<MagazineModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
        }
    }
}
