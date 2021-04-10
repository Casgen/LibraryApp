﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository
{
    public class BookRepository : Repository<BookModel>
    {
        public BookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
            
        }
    }
}
