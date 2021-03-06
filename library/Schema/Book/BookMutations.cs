using DataLayer;
using DataLayer.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace Library.Schema.Book
{
    public class BookMutations
    {
        public async Task<BookModel> CreateBook(BookModel bookModel, [ScopedService] LibraryDbContext context)
        {
            await context.Books.AddAsync(bookModel);
            await context.Publications.AddAsync(bookModel.Publication);
            if (bookModel.Publication.Image != null)
            {
                await context.Images.AddAsync(bookModel.Publication.Image);
            }
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
        public async Task<BookModel> UpdateBook(BookModel bookModel, [ScopedService] LibraryDbContext context)
        {
            context.Books.Update(bookModel);
            await context.SaveChangesAsync();
            return bookModel;
        }

    }
}
