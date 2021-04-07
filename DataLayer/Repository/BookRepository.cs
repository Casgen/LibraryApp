using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class BookRepository
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public async Task<BookModel> GetBook(int id)
        {
            return await libraryDbContext.Books.FindAsync(id);
        }

        public async Task CreateBook(BookModel bookModel)
        {
            await libraryDbContext.Books.AddAsync(bookModel);
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
