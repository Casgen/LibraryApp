using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Review
{
    public class ReviewType : ObjectType<ReviewModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ReviewModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            //descriptor.Field(b => b.AuthorId).Type<DecimalType>();
        }
    }
}
