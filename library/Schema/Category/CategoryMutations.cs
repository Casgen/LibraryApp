using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    [ExtendObjectType("MutationQuery")]
    public class CategoryMutations
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryMutations(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel categoryModel)
        {
            await categoryRepository.CreateAsync(categoryModel);
            return categoryModel;
        }

        public async Task<CategoryModel> DeleteCategory(int id)
        {
            CategoryModel categoryModel = await categoryRepository.DeleteAsync(id);
            return categoryModel;
        }
    }
}
