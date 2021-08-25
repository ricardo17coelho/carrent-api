using System;
using System.Collections.Generic;
using AutoMapper;
using Carrent.CarManagement.Api;
using Carrent.CarManagement.Application;
using Carrent.CarManagement.Domain;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Moq;
using Xunit;

namespace CarRent.Test.CarManagement
{
    public class TestCarBrandController
    {
        private readonly IMapper _mapper;
        private readonly ICarService _service;

        private readonly Mock<IRepository<Car, Guid>> _repository;

        private readonly CarClass _basicClass = new()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 12,
            Type = "Basic"
        };
        private readonly CarClass _mediumClass = new()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 20,
            Type = "Medium"
        };
        private readonly CarClass _luxuryClass = new()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 130,
            Type = "Luxury"
        };

        private readonly List<Car> _cars;
        public TestCarBrandController()
        {

            var carClasses = new List<CarClass>()
            {
                _basicClass,
                _mediumClass,
                _luxuryClass
            };
            _cars = new List<Car>()
            {
                new Car()
                {
                    Id = Guid.NewGuid(),
                    BrandId = Guid.NewGuid(),
                    Class = _basicClass,
                    ClassId = _basicClass.Id,
                    TypeId = Guid.NewGuid()
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<Car, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_cars);
            _repository.Setup(x => x.Insert(It.IsAny<Car>()));

            _service = new CarService(_repository.Object);
        }

        //[Fact]
        //public void TestGetAll()
        //{
        //    var controller = new CarController(_service, _mapper);

        //    var result = controller.Get();

        //    result.Should().NotBeEmpty().And.BeEquivalentTo(_cars, o => o.ExcludingMissingMembers());
        //}

        [Fact]
        public void TestAdd()
        {
            var controller = new CarController(_service, _mapper);

            var carToAdd = new CarRequestCreateDto()
            {
                Brand = "Hyundai",
                ClassId = _luxuryClass.Id,
                Type = "PW"
            };

            controller.Post(carToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Car>()));
        }
    }
}