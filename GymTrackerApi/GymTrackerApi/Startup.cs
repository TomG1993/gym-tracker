using GymTrackerApi.Models;
using GymTrackerApi.Repository;
using GymTrackerApi.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GymTrackerApi
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
            services.AddCors(); // Make sure you call this previous to AddMvc

            services.AddControllers();

            services.AddDbContext<GymTrackerContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("GymTrackerContext")));

            services.AddTransient<IUserDetailsRepository, UserDetailsRepository>();
            //services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Make sure you call this before calling app.UseMvc()
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}