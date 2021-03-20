using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LibaryDbContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibaryDbContext(DbContextOptions options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
