using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class CategoryRepository : Repository<CategoryModel>
    {
        public CategoryRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {

        }
    }
}
