using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    [ExtendObjectType("MutationQuery")]
    public class BookMutations
    {
        private readonly BookRepository bookRepository;

        public BookMutations(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<BookModel> CreateBook(BookModel bookModel)
        {
            await bookRepository.CreateAsync(bookModel);
            return bookModel;
        }

        public async Task<BookModel> DeleteBook(int id)
        {
            BookModel bookModel = await bookRepository.DeleteAsync(id);
            return bookModel;
        }

    }
}
