using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Category
{
    [ExtendObjectType(Name = "RootQuery")]
    public class CategoryQueries
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryQueries(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<CategoryModel> GetCategory(int id)
        {
            CategoryModel category = await categoryRepository.GetByIdAsync(id);
            return category;
        }
        public async Task<List<CategoryModel>> GetCategories()
        {
            List<CategoryModel> categories = (List<CategoryModel>) await categoryRepository.GetAllAsync();
            return categories;
        }
    }
}
