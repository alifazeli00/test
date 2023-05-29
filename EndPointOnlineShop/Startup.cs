
using Application;
using Application.Catalogs;
using Application.Context;
using Application.Discounts;
using Application.HUb;
using Application.Orders;
using Application.Visitor;
using Domain;
using EndPointOnlineShop.Hubs;
using EndPointOnlineShop.Utilities.Filters;
using EndPointOnlineShop.Utilities.Middlewares;
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

namespace EndPointOnlineShop
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
          services.AddDistributedMemoryCache();
      //     services  ager khasti to payga zakhire she ye config dige dare  ya in ya on balii mire to ram mizare
            services.AddTransient<IOrder, Orderr>();
            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            services.AddTransient<ISaveVisitor,SaveVisitor>();
            services.AddSignalR(); services.AddScoped<SaveVisitorFilter>();
            services.AddScoped<IChatAdmin,ChatAdmin>();
            services.AddTransient<IBasket,Basket>();
            services.AddTransient<IDiscount,Discount>();
            services.AddAuthorization();
            services.AddControllersWithViews();
            services.AddTransient<IDataBaceContext, DataBaceContext>();
            services.AddTransient<ICatalogItem, catalogItem>();
            services.AddTransient<ICatalogType, catalogType>();
            services.AddAutoMapper(typeof(CatalogMappingProfile));
            services.AddTransient<IPlpItems, PlpItems>();
            services.AddTransient<IPdpItems,PdpItems>();
            services.AddTransient<IPeyment,Peymentt>();
            string contectionString = @"server=.; Initial Catalog=OnlineShope_StoreDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>
                (option => option.UseSqlServer(contectionString));
           
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
                option.LoginPath = "/Acoont/login";
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
            app.UseSaveVisitorId();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<Client>("/chathub");
                //   endpoints.MapHub<adminsaporttest>("/Suphub");
                endpoints.MapHub<Suport>("/Suphub");

            });

            
        }
    }
}
