using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    public class CategoryInputType : InputObjectType<CategoryModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CategoryModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Name).Type<StringType>();
        }
    }
}
