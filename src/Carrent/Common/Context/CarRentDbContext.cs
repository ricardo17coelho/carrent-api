using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.CarManagement.Domain;
using Carrent.CustomerManagement.Domain;
using Carrent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Carrent.Common.Context
{
    public class CarRentDbContext : BaseDbContext
    {
        public CarRentDbContext(DbContextOptions options) : base(options) { }

        //Add the Main Data Models
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModelBinding<Car, Guid>(modelBuilder);
            //ConfigureModelBinding<CarClass, Guid>(modelBuilder);
            ConfigureModelBinding<Customer, Guid>(modelBuilder);
            ConfigureModelBinding<Reservation, Guid>(modelBuilder);
            ConfigureModelBinding<CarType, Guid>(modelBuilder);
            ConfigureModelBinding<CarBrand, Guid>(modelBuilder);

            List<CarClass> carClasses = new()
            {
                new CarClass(){ 
                    Id =  Guid.NewGuid(),
                    Type = "Classic",
                    PricePerDay = 12
                    },
                new CarClass(){
                    Id = Guid.NewGuid(),
                    Type = "Basic",
                    PricePerDay = 8
                },
                new CarClass(){
                    Id = Guid.NewGuid(), 
                    Type = "Medium",
                    PricePerDay = 20 
                },
                new CarClass(){
                    Id = Guid.NewGuid(), 
                    Type = "Luxury",
                    PricePerDay = 40 
                }
            };
            carClasses.ForEach(carClass => modelBuilder.Entity<CarClass>().HasData(carClass));
        }
    }
}
