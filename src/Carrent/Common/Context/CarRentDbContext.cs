using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.CarManagement.Domain;
using Carrent.ContractManagement.Domain;
using Carrent.CustomerManagement.Domain;
using Carrent.ReservationManagement.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public DbSet<RentalContract> RentalContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var env = this.GetService<IWebHostEnvironment>();
            Console.WriteLine($"EnvironmentName: {env.EnvironmentName}");
            if (env.EnvironmentName == "Development")
            {
                // seed carClasses
                CarClass carClassClassic = new ()
                {
                    Id = Guid.NewGuid(),
                    Type = "Classic",
                    PricePerDay = 12
                };
                CarClass carClassBasic = new ()
                {
                    Id = Guid.NewGuid(),
                    Type = "Basic",
                    PricePerDay = 8
                };
                CarClass carClassMedium = new ()
                {
                    Id = Guid.NewGuid(),
                    Type = "Medium",
                    PricePerDay = 20
                };
                CarClass carClassLuxury = new ()
                {
                    Id = Guid.NewGuid(),
                    Type = "Luxury",
                    PricePerDay = 40
                };
                List<CarClass> carClasses = new()
                {
                    carClassClassic,
                    carClassBasic,
                    carClassMedium,
                    carClassLuxury
                };
                carClasses.ForEach(carClass => modelBuilder.Entity<CarClass>().HasData(carClass));

                // seed CarBrands
                CarBrand _brandFerrari = new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Ferrari"
                };
                CarBrand _brandBMW = new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "BMW"
                };
                CarBrand _brandMercedes = new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Mercedes"
                };
                CarBrand _brandAudi = new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Audi"
                };
                List<CarBrand> carBrands = new()
                {
                    _brandFerrari,
                    _brandBMW,
                    _brandMercedes,
                    _brandAudi

                };
                carBrands.ForEach(carBrand => modelBuilder.Entity<CarBrand>().HasData(carBrand));

                // seed CarTypes
                CarType _carTypeSUV = new()
                {
                    Id = Guid.NewGuid(),
                    Title = "SUV"
                };
                CarType _carTypeSports = new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Sports"
                };

                CarType _carTypeElectric = new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Electric"
                };
                List<CarType> carTypes= new()
                {
                    _carTypeSUV,
                    _carTypeSports,
                    _carTypeElectric

                };
                carTypes.ForEach(carType => modelBuilder.Entity<CarType>().HasData(carType));

                // seed Customers
                Customer _customerJoe = new()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Joe",
                    Lastname = "Doe",
                    Street = "Fakestreet 1",
                    Country = "CH",
                    Town = "St. Gallen",
                    Zip = "9000"
                };
                Customer _customerThomas = new()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Thomas",
                    Lastname = "Schmit",
                    Street = "Fakestreet 1",
                    Country = "CH",
                    Town = "St. Gallen",
                    Zip = "9000"
                };
                Customer _customerHans = new()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Hans",
                    Lastname = "Mueller",
                    Street = "Fakestreet 1",
                    Country = "CH",
                    Town = "St. Gallen",
                    Zip = "9000"
                };
                List<Customer> customers = new()
                {
                    _customerJoe,
                    _customerThomas,
                    _customerHans

                };
                customers.ForEach(customer => modelBuilder.Entity<Customer>().HasData(customer));

                // seed Cars
                Car _carFerrariCalifornia= new()
                {
                    Id = Guid.NewGuid(),
                    BrandId = _brandFerrari.Id,
                    TypeId = _carTypeSports.Id,
                    ClassId = carClassLuxury.Id,
                    Model = "California",
                    Kilometers = 100,
                    HorsePower = 1500,
                    RegistrationYear = 2020
                };
                Car _carMercedesGla= new()
                {
                    Id = Guid.NewGuid(),
                    BrandId = _brandFerrari.Id,
                    TypeId = _carTypeSUV.Id,
                    ClassId = carClassMedium.Id,
                    Model = "GLA 220",
                    Kilometers = 2567,
                    HorsePower = 300,
                    RegistrationYear = 2019
                };
                Car _carBmwI18 = new()
                {
                    Id = Guid.NewGuid(),
                    BrandId = _brandBMW.Id,
                    TypeId = _carTypeSports.Id,
                    ClassId = carClassBasic.Id,
                    Model = "i18",
                    Kilometers = 10000,
                    HorsePower = 143,
                    RegistrationYear = 2014
                };
                List<Car> cars = new()
                {
                    _carFerrariCalifornia,
                    _carMercedesGla,
                    _carBmwI18

                };
                cars.ForEach(car => modelBuilder.Entity<Car>().HasData(car));

                ConfigureModelBinding<Reservation, Guid>(modelBuilder);
                ConfigureModelBinding<RentalContract, Guid>(modelBuilder);
            } else
            {
                ConfigureModelBinding<CarClass, Guid>(modelBuilder);
                ConfigureModelBinding<CarBrand, Guid>(modelBuilder);
                ConfigureModelBinding<CarType, Guid>(modelBuilder);
                ConfigureModelBinding<Car, Guid>(modelBuilder);
                ConfigureModelBinding<Customer, Guid>(modelBuilder);
                ConfigureModelBinding<Reservation, Guid>(modelBuilder);
                ConfigureModelBinding<RentalContract, Guid>(modelBuilder);
            }




            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column
            //modelBuilder.Entity<RentalContract>()
            //    .Property(p => p.TotalCosts)
            //    .HasColumnType("decimal(18,2)");


            //modelBuilder.Entity<RentalContract>()
            //   .HasRequired(f => f.)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);


            //modelBuilder.Entity<RentalContract>()
            // .HasOne(b => b.Reservation)
            // .WithOne(t => t.Id)
            // //.WithMany(a => a.Id)
            // .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RentalContract>()
                .HasOne(e => e.Reservation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<RentalContract>()
            // .HasOne(b => b.Car)
            // .IsRequired()
            // .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
