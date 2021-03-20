using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LibaryDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }

        public LibaryDbContext(DbContextOptions options): base(options) { }
    }
}
