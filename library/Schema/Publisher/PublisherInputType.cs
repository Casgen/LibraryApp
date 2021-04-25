﻿using DataLayer.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Publisher
{
    public class PublisherInputType : InputObjectType<PublisherModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PublisherModel> descriptor)
        {
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.Publications).Ignore();
        }
    }
}
