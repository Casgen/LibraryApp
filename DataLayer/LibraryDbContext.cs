using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LibraryDbContext : IdentityDbContext<UserModel>
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<MagazineModel> Magazines { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public override DbSet<UserModel> Users { get; set; }
        public DbSet<PublicationModel> Publications { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserModel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PublicationModel>().HasOne(x => x.Book).WithOne(x => x.Publication).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PublicationModel>().HasOne(x => x.Magazine).WithOne(x => x.Publication).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ImageModel>().HasOne(x => x.Publication).WithOne(x => x.Image).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserModel>().HasAlternateKey(x => x.Username);
            //modelBuilder.Entity<UserModel>().HasAlternateKey(x => x.Email);
            base.OnModelCreating(modelBuilder);
        }
    }
}
