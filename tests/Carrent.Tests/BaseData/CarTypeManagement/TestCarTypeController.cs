using System;
using System.Collections.Generic;
using AutoMapper;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Models;
using Carrent.BaseData.CarTypesManagement.Api;
using Carrent.BaseData.CarTypesManagement.Application;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Moq;
using Xunit;

namespace CarRent.Test.BaseData.CarBrandManagement
{
    public class TestCarTypeController
    {
        private readonly IMapper _mapper;
        private readonly ICarTypeService _service;

        private readonly Mock<IRepository<CarType, Guid>> _repository;

        private readonly CarType _suvVarType = new()
        {
            Title = "SUV"
        };
        private readonly CarType _sportsVarType = new()
        {
            Title = "Sports"
        };
        private readonly CarType _electricVarType = new()
        {
            Title = "Electric"
        };

        private readonly List<CarType> _carTypes;
        public TestCarTypeController()
        {

            var carClasses = new List<CarType>()
            {
                _suvVarType,
                _sportsVarType,
                _electricVarType
            };
            _carTypes = new List<CarType>()
            {
                new CarType()
                {
                    Title = "SUV"
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<CarType, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_carTypes);
            _repository.Setup(x => x.Insert(It.IsAny<CarType>()));

            _service = new CarTypeService(_repository.Object);
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new CarTypeController(_service, _mapper);

            var carToAdd = new CarTypeRequestCreateDto()
            {
                Title = "Electric"
            };

            controller.Post(carToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<CarType>()));
        }
    }
}