using Carrent.CarManagement.Application;
using Carrent.CarManagement.Domain;
using Carrent.CarManagement.Infrastructure;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent
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
            //add the database context
            services.AddDbContext<CarRentDbContext>(config =>
            {
                Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
                config.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICarService, CarService>();
            services.AddScoped<IRepository<Car, Guid>, CarRepository>();

            services.AddTransient<ICarClassService, CarClassService>();
            services.AddScoped<IRepository<CarClass, Guid>, CarClassRepository>();

            services.AddAutoMapper(typeof(CarProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Carrent",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact { Name = "Ricardo Coelho", Email = "devel@rmorgado.ch" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CarRentDbContext carRentDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carrent v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //run all migrations
            carRentDbContext.Database.Migrate();
        }
    }
}
