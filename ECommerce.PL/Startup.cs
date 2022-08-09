using ECommerce.BLL;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Repository;
using ECommerce.DAL.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PL
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
            services.AddControllersWithViews();
            services.AddControllers();
            //cong for connection string
            services.AddDbContextPool<ProductContext>(opts =>
           opts.UseSqlServer(Configuration.GetConnectionString("ConnecStr")));
            //congig for dependancies
            services.AddScoped<IproductRep, ProductRep>();
            services.AddScoped<ICustomerRep, CustomerRep>();
            services.AddScoped<IOrderRep, OrderRep>();
            services.AddScoped<IOrderProduct, OrderProductRep>();

            //automapper
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            //identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ProductContext>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider); ;
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 1;
            //});
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(a => a.MapDefaultControllerRoute());
        }
    }
}
