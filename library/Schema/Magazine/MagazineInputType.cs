﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Magazine
{
    public class MagazineInputType : InputObjectType<MagazineModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<MagazineModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
        }
    }
}
