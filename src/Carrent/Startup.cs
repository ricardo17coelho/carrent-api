using Carrent.BaseData.CarBrandManagement.Application;
using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarBrandManagement.Infrastructure;
using Carrent.BaseData.CarClassManagement.Application;
using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.BaseData.CarClassManagement.Infrastructure;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Infrastructure;
using Carrent.BaseData.CarTypesManagement.Application;
using Carrent.CarManagement.Application;
using Carrent.CarManagement.Domain;
using Carrent.CarManagement.Infrastructure;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Carrent.ContractManagement.Application;
using Carrent.ContractManagement.Domain;
using Carrent.ContractManagement.Infrastructure;
using Carrent.CustomerManagement.Application;
using Carrent.CustomerManagement.Domain;
using Carrent.CustomerManagement.Infrastructure;
using Carrent.ReservationManagement.Application;
using Carrent.ReservationManagement.Domain;
using Carrent.ReservationManagement.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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
            services.AddControllers();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped<IRepository<Customer, Guid>, CustomerRepository>();

            services.AddTransient<ICarService, CarService>();
            services.AddScoped<IRepository<Car, Guid>, CarRepository>();

            services.AddTransient<ICarClassService, CarClassService>();
            services.AddScoped<IRepository<CarClass, Guid>, CarClassRepository>();

            services.AddTransient<IReservationService, ReservationService>();
            services.AddScoped<IRepository<Reservation, Guid>, ReservationRepository>();

            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddScoped<IRepository<CarType, Guid>, CarTypeRepository>();

            services.AddTransient<ICarBrandService, CarBrandService>();
            services.AddScoped<IRepository<CarBrand, Guid>, CarBrandRepository>();            
            
            services.AddTransient<IContractService, ContractService>();
            services.AddScoped<IRepository<RentalContract, Guid>, ContractRepository>();
            services.AddScoped<ReservationRepository>();

            services.AddAutoMapper(typeof(CarProfile), typeof(CustomerProfile), typeof(ReservationProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Carrent",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact { Name = "Ricardo Coelho", Email = "devel@rmorgado.ch" }
                });
                //File.WriteAllText("swagger.json", c.ToString());
            });

            // VARIANT 1
            //services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //           .AllowAnyMethod()
            //           .AllowAnyHeader();
            //}));
            //services.AddMvc(options => options.EnableEndpointRouting = false);

            // VARIANT 2
            services.AddCors();
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

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Make sure you call this before calling app.UseMvc()
            //app.UseCors(
            //    options => options.WithOrigins("localhost:8080").AllowAnyMethod()
            //);
            //app.UseMvc();

            // VARIANT 1
            //app.UseCors("MyPolicy");
            //app.UseMvc();

            // VARIANT 2
            //https://jasonwatmore.com/post/2020/05/20/aspnet-core-api-allow-cors-requests-from-any-origin-and-with-credentials
            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials

            //carRentDbContext.Database.EnsureCreated();
            //run all migrations
            carRentDbContext.Database.Migrate();
        }
    }
}
