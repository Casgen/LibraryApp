using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;
using Library.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Image
{
    public class ImageType : ObjectType<ImageModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ImageModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.FileExtension).Type<StringType>();
        }
    }
}
