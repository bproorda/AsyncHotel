using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncHotel.Data;
using AsyncHotel.Data.Repositories;
using AsyncHotel.Data.Repositories.DatabaseRepositories;
using AsyncHotel.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncHotel
{
    public class Startup
    {
        // 1. Property to hold our Configuration info
        public IConfiguration Configuration { get; }

        // 2. Add constructor to received the IConfiguration (via magic)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // 3. Register the DbContext with the app, using our Connection String
            services.AddDbContext<HotelDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            //Regristration for controllers and repositories
            services.AddTransient<IHotelRepository, DatabaseHotelRepository>();
            services.AddTransient<IRoomRepository, DatabaseRoomRepository>();
            services.AddTransient<IAmenityRepository, DatabaseAmenityRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
