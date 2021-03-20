using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LibaryDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibaryDbContext(DbContextOptions options): base(options) { }
    }
}
