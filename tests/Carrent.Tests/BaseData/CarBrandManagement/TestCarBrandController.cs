using System;
using System.Collections.Generic;
using AutoMapper;
using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarBrandManagement.Models;
using Carrent.BaseData.CarBrandManagement.Api;
using Carrent.BaseData.CarBrandManagement.Application;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Moq;
using Xunit;

namespace CarRent.Test.BaseData.CarBrandManagement
{
    public class TestCarBrandController
    {
        private readonly IMapper _mapper;
        private readonly ICarBrandService _service;

        private readonly Mock<IRepository<CarBrand, Guid>> _repository;

        private readonly CarBrand _mercedesCarType = new()
        {
            Title = "Mercedes"
        };
        private readonly CarBrand _audiCarType = new()
        {
            Title = "Audi"
        };
        private readonly CarBrand _bmwCarType = new()
        {
            Title = "BMW"
        };

        private readonly List<CarBrand> _carsBrands;
        public TestCarBrandController()
        {

            var carClasses = new List<CarBrand>()
            {
                _mercedesCarType ,
                _audiCarType,
                _bmwCarType
            };
            _carsBrands = new List<CarBrand>()
            {
                new CarBrand()
                {
                    Title = "Ferrari"
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<CarBrand, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_carsBrands);
            _repository.Setup(x => x.Insert(It.IsAny<CarBrand>()));

            _service = new CarBrandService(_repository.Object);
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new CarBrandController(_service, _mapper);

            var carToAdd = new CarBrandRequestCreateDto()
            {
                Title = "Ferrari"
            };

            controller.Post(carToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<CarBrand>()));
        }
    }
}