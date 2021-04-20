using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.Book
{
    public class BookQueries
    {
        public async Task<BookModel> GetBook(int id, [ScopedService] LibraryDbContext context)
        {
            return await context.Books.FindAsync(id);
        }
        public IQueryable<BookModel> GetBooks([ScopedService] LibraryDbContext context)
        {
            return context.Books;
        }
    }
}
