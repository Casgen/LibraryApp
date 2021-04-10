using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    public class CategoryType : ObjectType<CategoryModel>
    {
        protected override void Configure(IObjectTypeDescriptor<CategoryModel> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Name).Type<StringType>();
        }
    }
}
