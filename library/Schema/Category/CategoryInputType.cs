using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    public class CategoryInputType : InputObjectType<CategoryModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CategoryModel> descriptor)
        {
            descriptor.Field(b => b.Id).Ignore();
            descriptor.Field(b => b.Name).Type<StringType>();
            descriptor.Field(b => b.Publications).Ignore();
        }
    }
}
