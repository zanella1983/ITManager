using ITManager.Application.Services;
using ITManager.Application.Services.Imp;
using ITManager.Domain.Repositories;
using ITManager.Repositories;
using ITManager.Repositories.lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITManager.WebMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public const string ConnectionString = "server=127.0.0.1;port=3306;user=root;password=1234567;database=dev_itmanager";


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Configurações MySql EF Core
            services.AddEntityFrameworkMySql()
             .AddDbContext<ITManagerDbContext>(options =>
             {
                 options.UseLazyLoadingProxies();
                 options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString),
                      opts =>
                      {
                          opts.MigrationsAssembly(typeof(ITManagerDbContext).Assembly.GetName().Name);
                      });
             });
            #endregion

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
