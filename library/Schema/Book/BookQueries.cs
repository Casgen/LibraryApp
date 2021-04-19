﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace Library.Schema.Book
{
    public class BookQueries
    {
        private readonly BookRepository bookRepository;

        public BookQueries(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<BookModel> GetBook(int id)
        {
            BookModel book = await bookRepository.GetByIdAsync(id);
            return book;
        }
        public async Task<List<BookModel>> GetBooks()
        {
            List<BookModel> books = (List<BookModel>) await bookRepository.GetAllAsync();
            return books;
        }
    }
}
