using ClinicManagementSystemv2022.Models;
using ClinicManagementSystemv2022.Repository;
using CMSV2022.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemv2022
{
    public class Startup
    {
        //Changed by Leema
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // ConnectionString for Database, inject as dependency
 
             services.AddDbContext<ClinicManagementSystemContext>(db =>
             db.UseSqlServer(Configuration.GetConnectionString("ClinicManagementSystemDBConnection")));

             //add dependency injection of EmployeeReository
             services.AddScoped<IEmployeeRepository, EmployeeRepository>();
             services.AddScoped<IPharmacistRepository, PharmacistRepository>();
             services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
        }

        // changes by Sajitha

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
