using AutoMapper;
using Carrent.CarManagement.Api;
using Carrent.CarManagement.Application;
using Carrent.CarManagement.Domain;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Carrent.Tests
{
    [TestFixture]
    public class TestCarController
    {
        private readonly IMapper _mapper;
        private readonly ICarService _service;

        private readonly Mock<IRepository<Car, Guid>> _repository;

        private readonly CarClass _basicClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 12,
            Type = "Basic"
        };
        private readonly CarClass _mediumClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 20,
            Type = "Medium"
        };
        private readonly CarClass _luxuryClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 130,
            Type = "Luxury"
        };

        private readonly List<Car> _cars;
        public TestCarController()
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
                    Brand = "Toyota",
                    Class = _basicClass,
                    ClassId = _basicClass.Id,
                    Type = "PW"
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

        [Test]
        public void TestGetAll()
        {
            var controller = new CarController(_service, _mapper);

            var result = controller.Get();

            //result.Should().NotBeEmpty().And.BeEquivalentTo(_cars, o => o.ExcludingMissingMembers());
            Assert.AreEqual(result, _cars);
        }

        [Test]
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
