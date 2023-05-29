using Admin.EndPoint.MappingProfiles;
using Admin.Midlewares;
using Application.Catalogs;
using Application.Context;
using Application.Discounts;
using Application.HUb;
using Application.Visitor;
using Domain;
using Infrastructure.ExternalApi.ImgeServer;
using Infrastructure.Hubs;
using Infrastructure.MappingProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin
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
            var ss = services.AddControllersWithViews();
#if DEBUG
            ss.AddRazorRuntimeCompilation();
#endif
            services.AddAuthorization();
            services.AddSignalR();
            services.AddTransient<IChatAdmin,ChatAdmin>();
            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            services.AddControllersWithViews();
            services.AddTransient<IRports,Rports>();
                services.AddTransient<IDataBaceContext, DataBaceContext>();
            services.AddTransient<ICatalogItem, catalogItem>();     
            services.AddTransient<ICatalogType, catalogType>();
            services.AddTransient<IPlpItems, PlpItems>();
            services.AddTransient<IDiscount,Discount>();
            string contectionString = @"server=.; Initial Catalog=OnlineShope_StoreDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>(option => option.UseSqlServer(contectionString));
            services.AddAutoMapper(typeof(CatalogMappingProfile));
            services.AddAutoMapper(typeof(CatalogVMMappingProfile));
            services.AddControllersWithViews();
            services.AddTransient<ImageUploderService,mageUploderService>();

            services.AddDbContext<DataBaceContextIdentity>(option => option.UseSqlServer(contectionString));
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<DataBaceContextIdentity>().AddDefaultTokenProviders()
               .AddRoles<IdentityRole>().AddErrorDescriber<IdentityErrorDescriber>();
            services.AddAuthorization();
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequiredUniqueChars = 0;


            });
            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;

                option.ExpireTimeSpan = TimeSpan.FromDays(365);
                option.LoginPath = "/Accountt/login";
                option.LogoutPath = "";
                option.AccessDeniedPath = "";
                option.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseCustomExceptionHandler();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Accountt}/{action=Login}/{id?}");
                endpoints.MapHub<Suport>("/Suphub");


                endpoints.MapHub<Client>("/chathub");
            });
        }
    }
}
