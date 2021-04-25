using DataLayer.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Review
{
    public class ReviewInputType : InputObjectType<ReviewModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReviewModel> descriptor)
        {
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.User).Ignore();
            descriptor.Field(b => b.Publication).Ignore();
        }
    }
}
