using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sandbox.Data;
using sandbox.Models.Interfaces;
using sandbox.Models.Services;

namespace sandbox
{
    public class Startup
    {
        // Adding `Configuration` will ask to add variable
        public IConfiguration Configuration { get; }

        /// TODO 6: add the constructor and content in it
        /// TODO 7: adding migration will give you error if you dont ask tools
        public Startup(IConfiguration configuration)
        {
            // this is for secret
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(); // TODO 1: add this 

            // TODO 4. type in Install-Package Microsoft.EntityFrameworkCore.SqlServer to the console
            // TODO 5. paste in following code
            services.AddDbContext<AnimalShelterDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // TODO DI: add this everytime you see Idoggys you instantiate service
            services.AddTransient<IDoggys, DogsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            // TODO 2: add this
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
