using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Author
{
    public class AuthorMutations
    {
        public async Task<AuthorModel> CreateAuthor(AuthorModel authorModel, [ScopedService] LibraryDbContext context)
        {
            await context.Authors.AddAsync(authorModel);
            await context.SaveChangesAsync();
            return authorModel;
        }

        public async Task<AuthorModel> DeleteAuthor(int id, [ScopedService] LibraryDbContext context)
        {
            AuthorModel authorModel = await context.Authors.FindAsync(id);
            context.Authors.Remove(authorModel);
            await context.SaveChangesAsync();
            return authorModel;
        }

        public async Task<AuthorModel> UpdateAuthor(AuthorModel authorModel, [ScopedService] LibraryDbContext context)
        {
            context.Authors.Update(authorModel);
            await context.SaveChangesAsync();
            return authorModel;
        }
    }
}
