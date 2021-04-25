using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Image
{
    public class ImageInputType : InputObjectType<ImageModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ImageModel> descriptor)
        {
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.FileExtension).Type<StringType>();
            descriptor.Field(b => b.Publication).Ignore();
        }
    }
}
