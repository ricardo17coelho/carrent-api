using Carrent.CarManagement.Domain;
using Carrent.CustomerManagement.Domain;
using Carrent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModelBinding<Car, Guid>(modelBuilder);
            //ConfigureModelBinding<CarClass, Guid>(modelBuilder);
            ConfigureModelBinding<Customer, Guid>(modelBuilder);
            ConfigureModelBinding<Reservation, Guid>(modelBuilder);

            List<CarClass> carClasses = new List<CarClass>
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
