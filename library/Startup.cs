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
using Library.DataLoader;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace library
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly ILoggerFactory _loggerFactory
                    = LoggerFactory.Create(builder => builder.AddDebug().AddFilter((category, level) => level == LogLevel.Information));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddGraphQLServer()
                .AddAuthorization()
                .AddFiltering()
                .AddQueryType<RootQuery>()
                .AddMutationType<RootMutation>()
                .AddDataLoader<AuthorByIdDataLoader>()
                .AddDataLoader<BookByIdDataLoader>()
                .AddDataLoader<CategoryByIdDataLoader>()
                .AddDataLoader<ImageByIdDataLoader>()
                .AddDataLoader<MagazineByIdDataLoader>()
                .AddDataLoader<PublicationByIdDataLoader>()
                .AddDataLoader<PublisherByIdDataLoader>()
                .AddDataLoader<ReservationByIdDataLoader>()
                .AddDataLoader<ReviewByIdDataLoader>()
                .AddDataLoader<RoleByIdDataLoader>()
                .AddDataLoader<UserByIdDataLoader>();

            services.AddHttpContextAccessor();

            services.AddAuthorization();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();

            services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:3000",
                                                      "http://joseff-001-site1.ctempurl.com/")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                              }));
            
            services.AddPooledDbContextFactory<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
                options.UseLoggerFactory(_loggerFactory);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000",
                                                      "http://joseff-001-site1.ctempurl.com/")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());

            app.UseRouting();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            app
                .UseRouting()
                .UseEndpoints(endpoints => {
                endpoints.MapGraphQL();
            });
        }
    }
}
