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
            services.AddControllers();

            services.AddGraphQLServer()
                .AddQueryType(x => x.Name("RootQuery"))
                    .AddTypeExtension<BookQueries>()
                        .AddType<BookType>()
                    .AddTypeExtension<PublisherQueries>()
                        .AddType<PublisherType>()
                    .AddTypeExtension<ReservationQueries>()
                        .AddType<ReservationType>()
                    .AddTypeExtension<ReviewQueries>()
                        .AddType<ReviewType>()
                    .AddTypeExtension<RoleQueries>()
                        .AddType<RoleType>()
                    .AddTypeExtension<UserQueries>()
                        .AddType<UserType>()
                    .AddTypeExtension<AuthorQueries>()
                        .AddType<AuthorType>()
                    .AddTypeExtension<CategoryQueries>()
                        .AddType<CategoryType>()
                    .AddTypeExtension<ImageQueries>()
                        .AddType<ImageType>()
                    .AddTypeExtension<MagazineQueries>()
                        .AddType<MagazineType>()
                    .AddTypeExtension<PublicationQueries>()
                        .AddType<PublicationType>()
                .AddMutationType(x => x.Name("MutationQuery"))
                    .AddTypeExtension<BookMutations>()
                        .AddType<BookInputType>()
                    .AddTypeExtension<PublisherMutations>()
                        .AddType<PublisherInputType>()
                    .AddTypeExtension<ReservationMutations>()
                        .AddType<ReservationInputType>()
                    .AddTypeExtension<ReviewMutations>()
                        .AddType<ReviewInputType>()
                    .AddTypeExtension<RoleMutations>()
                        .AddType<RoleInputType>()
                    .AddTypeExtension<UserMutations>()
                        .AddType<UserInputType>()
                    .AddTypeExtension<AuthorMutations>()
                        .AddType<AuthorInputType>()
                    .AddTypeExtension<CategoryMutations>()
                        .AddType<CategoryInputType>()
                    .AddTypeExtension<ImageMutations>()
                        .AddType<ImageInputType>()
                    .AddTypeExtension<MagazineMutations>()
                        .AddType<MagazineInputType>()
                    .AddTypeExtension<PublicationMutations>()
                        .AddType<PublicationInputType>();


            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddTransient<AuthorRepository>();
            services.AddTransient<BookRepository>();
            services.AddTransient<CategoryRepository>();
            services.AddTransient<ImageRepository>();
            services.AddTransient<MagazineRepository>();
            services.AddTransient<PublicationRepository>();
            services.AddTransient<PublisherRepository>();
            services.AddTransient<ReservationRepository>();
            services.AddTransient<ReviewRepository>();
            services.AddTransient<RoleRepository>();
            services.AddTransient<UserRepository>();
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

            app.UseAuthorization();

            app
                .UseRouting()
                .UseEndpoints(endpoints => {
                endpoints.MapGraphQL();
            });
        }
    }
}
