using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    public class CategoryMutations
    {
        public async Task<CategoryModel> CreateCategory(CategoryModel categoryModel, [ScopedService] LibraryDbContext context)
        {
            await context.Categories.AddAsync(categoryModel);
            await context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<CategoryModel> DeleteCategory(int id, [ScopedService] LibraryDbContext context)
        {
            CategoryModel categoryModel = await context.Categories.FindAsync(id);
            context.Categories.Remove(categoryModel);
            await context.SaveChangesAsync();
            return categoryModel;
        }
    }
}
