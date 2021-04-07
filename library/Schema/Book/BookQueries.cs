using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    [ExtendObjectType(Name = "RootQuery")]
    public class BookQueries
    {
        public async Task<BookModel> GetBook(String url)
        {
            throw new NotImplementedException();
        }
        public async Task<List<BookModel>> GetBooks(List<String> urls)
        {
            List<BookModel> books = new List<BookModel>();
            throw new NotImplementedException();
        }
    }
}
