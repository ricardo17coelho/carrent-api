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
            Id = Guid.NewGuid(),
            Title = "Mercedes"
        };
        private readonly CarBrand _audiCarType = new()
        {
            Id = Guid.NewGuid(),
            Title = "Audi"
        };
        private readonly CarBrand _bmwCarType = new()
        {
            Id = Guid.NewGuid(),
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
        public void CarBrandController_Add_VerifyItemsIsAdded()
        {
            // arrange
            var controller = new CarBrandController(_service, _mapper);
            var carBrandToAdd = new CarBrandRequestCreateDto()
            {
                Title = "Ferrari"
            };

            //act
            controller.Post(carBrandToAdd);

            //assert
            _repository.Verify(x => x.Insert(It.IsAny<CarBrand>()));
        }

        [Fact]
        public void CarBrandController_Edit_VerifyItemsIsUpdated()
        {
            //arrange
            var carBrandToUpdate = new CarBrandRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Title = "Ferrari 2"
            };
            var controller = new CarBrandController(_service, _mapper);

            //act
            controller.Put(carBrandToUpdate.Id, carBrandToUpdate);

            //assert
            _repository.Verify(x => x.Update(It.IsAny<CarBrand>()));
        }

        [Fact]
        public void CarBrandController_Delete_VerifyServiceIfWasCalled()
        {
            //arrange
            var carBrand = _mercedesCarType;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(It.IsAny<CarBrand>()));

            //act
            _service.Delete(carBrand);

            //assert
            _repository.Verify(r => r.Remove(carBrand));
        }

        [Fact]
        public void CarBrandController_DeleteById_VerifyIfServiceWasCalled()
        {
            //arrange
            var carBrand = _mercedesCarType;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(carBrand.Id));

            //act
            var controller = new CarBrandController(_service, _mapper);

            //act
             controller.Delete(carBrand.Id);

            //assert
            _repository.Verify(r => r.Remove(carBrand.Id));
        }

        [Fact]
        public void CarBrandController_FindById_ReturnsCarBrand()
        {
            //arrange
            var carBrandToGet = new CarBrandRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Title = "Ferrari 2"
            };

            _repository.Setup(x => x.FindById(carBrandToGet.Id));

            var controller = new CarBrandController(_service, _mapper);

            //act
            var result = controller.Get(carBrandToGet.Id);

            //assert
            _repository.Verify(r => r.FindById(carBrandToGet.Id));
        }


        [Fact]
        public void CarBrandController_GetAll_ReturnsList()
        {
            //arrange
            _repository.Setup(x => x.GetAll()).Returns(_carsBrands);
            var controller = new CarBrandController(_service, _mapper);

            //act
            var actionResult = controller.Get();
            var result = actionResult;

            //assert
            Assert.Equal(_carsBrands.Count, result.Count);
        }
    }
}