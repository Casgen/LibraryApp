using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using Library.Schema.Author;
using Library.Schema.Book;
using Library.Schema.Category;
using Library.Schema.Image;
using Library.Schema.Magazine;
using Library.Schema.Publication;
using Library.Schema.Publisher;
using Library.Schema.Reservation;
using Library.Schema.Review;
using Library.Schema.Role;
using Library.Schema.User;
using Library.Schema;

namespace library
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();

            services.AddGraphQLServer()
                .AddQueryType<RootQuery>()
                .AddMutationType<RootMutation>();


            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });


            services.AddScoped<AuthorRepository>()
                .AddScoped<AuthorQueries>()
                .AddScoped<AuthorMutations>();
            services.AddScoped<BookRepository>()
                .AddScoped<BookQueries>()
                .AddScoped<BookMutations>();
            services.AddScoped<CategoryRepository>()
                .AddScoped<CategoryQueries>()
                .AddScoped<CategoryMutations>();
            services.AddScoped<ImageRepository>()
                .AddScoped<ImageQueries>()
                .AddScoped<ImageMutations>();
            services.AddScoped<MagazineRepository>()
                .AddScoped<MagazineQueries>()
                .AddScoped<MagazineMutations>();
            services.AddScoped<PublicationRepository>()
                .AddScoped<PublicationQueries>()
                .AddScoped<PublicationMutations>();
            services.AddScoped<PublisherRepository>()
                .AddScoped<PublisherQueries>()
                .AddScoped<PublisherMutations>();
            services.AddScoped<ReservationRepository>()
                .AddScoped<ReservationQueries>()
                .AddScoped<ReservationMutations>();
            services.AddScoped<ReviewRepository>()
                .AddScoped<ReviewQueries>()
                .AddScoped<ReviewMutations>();
            services.AddScoped<RoleRepository>()
                .AddScoped<RoleQueries>()
                .AddScoped<RoleMutations>();
            services.AddScoped<UserRepository>()
                .AddScoped<UserQueries>()
                .AddScoped<UserMutations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app
                .UseRouting()
                .UseEndpoints(endpoints => {
                endpoints.MapGraphQL();
            });
        }
    }
}
