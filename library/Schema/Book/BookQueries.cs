using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    [ExtendObjectType(Name = "RootQuery")]
    public class BookQueries
    {
        private readonly BookRepository bookRepository;

        public BookQueries(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<BookModel> GetBook(int id)
        {
            BookModel book = await bookRepository.GetBook(id);
            return book;
        }
        public async Task<List<BookModel>> GetBooks(List<String> urls)
        {
            List<BookModel> books = new List<BookModel>();
            throw new NotImplementedException();
        }
    }
}
