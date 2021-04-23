using DataLayer;
using DataLayer.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Schema.Category
{
    public class CategoryQueries
    {
        public async Task<CategoryModel> GetCategory(int id, [ScopedService] LibraryDbContext context)
        {

            CategoryModel category = await context.Categories.FindAsync(id);
            return category;
        }
        public async Task<List<CategoryModel>> GetCategories([ScopedService] LibraryDbContext context)
        {
            List<CategoryModel> categories = await context.Categories.ToListAsync();
            return categories;
        }
    }
}
