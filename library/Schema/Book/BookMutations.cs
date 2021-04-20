using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    public class BookMutations
    {
        public async Task<BookModel> CreateBook(BookModel bookModel, [ScopedService] LibraryDbContext context)
        {
            await context.Books.AddAsync(bookModel);
            await context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<BookModel> DeleteBook(int id, [ScopedService] LibraryDbContext context)
        {
            BookModel bookModel = await context.Books.FindAsync(id);
            context.Books.Remove(bookModel);
            await context.SaveChangesAsync();
            return bookModel;
        }

    }
}
