using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Image
{
    public class ImageInputType : InputObjectType<ImageModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ImageModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.FileExtension).Type<StringType>();
        }
    }
}
