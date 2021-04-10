using DataLayer.Models;
using HotChocolate.Types;

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
