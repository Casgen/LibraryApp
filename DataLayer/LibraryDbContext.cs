using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<MagazineModel> Magazines { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PublicationModel> Publications { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasOne(x => x.Publication).WithOne(x => x.Book).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PublicationModel>().HasOne(x => x.Magazine).WithOne(x => x.Publication).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
