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
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using Library.Schema;
using Library.DataLoader;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;

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
                    = LoggerFactory.Create(builder => builder.AddDebug().AddEventLog().AddFilter((category, level) => level == LogLevel.Information));

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
                .AddDataLoader<UserByIdDataLoader>()
                .AddErrorFilter<GraphQLErrorFilter>();

            //services.AddHttpContextAccessor();

            //services.AddAuthorization();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(options => {
            //    options.Cookie.IsEssential = true;
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //    options.Cookie.SameSite = SameSiteMode.None;
            //});

            services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("https://localhost:44307/graphql", "https://localhost:3000")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials();
                              }));
            services.AddAuthorization();

            services.AddPooledDbContextFactory<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
                options.UseLoggerFactory(_loggerFactory);
            });
            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext());
            services.AddIdentity<UserModel, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<LibraryDbContext>()
            .AddDefaultTokenProviders();

            services.AddDataLayerServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDataLayerConfig();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            //var cookiePolicyOptions = new CookiePolicyOptions
            //{
            //    MinimumSameSitePolicy = SameSiteMode.None,
            //    Secure = CookieSecurePolicy.Always,
            //    ConsentCookie = { IsEssential = true },
            //    CheckConsentNeeded = context => false
            //};

           // app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting()
                .UseEndpoints(endpoints => {
                    endpoints.MapGraphQL();
                });
        }
    }
}
