using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Library.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Author
{
    public class AuthorQueries
    {
        public async Task<AuthorModel> GetAuthor(int id, [ScopedService] LibraryDbContext context)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task<List<AuthorModel>> GetAuthors([ScopedService] LibraryDbContext context)
        {
            return await context.Authors.ToListAsync();
        }
    }
}
