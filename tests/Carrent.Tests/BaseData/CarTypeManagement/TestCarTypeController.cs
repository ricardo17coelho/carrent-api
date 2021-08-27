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

namespace CarRent.Test.BaseData.CarTypeManagement
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
        public void CarTypeController_Add_VerifyItemsIsAdded()
        {
            // arrange
            var controller = new CarTypeController(_service, _mapper);
            var carBrandToAdd = new CarTypeRequestCreateDto()
            {
                Title = "SUV"
            };

            //act
            controller.Post(carBrandToAdd);

            //assert
            _repository.Verify(x => x.Insert(It.IsAny<CarType>()));
        }

        [Fact]
        public void CarTypeController_Edit_VerifyItemsIsUpdated()
        {
            //arrange
            var carBrandToUpdate = new CarTypeRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Title = "SUV"
            };
            var controller = new CarTypeController(_service, _mapper);

            //act
            controller.Put(carBrandToUpdate.Id, carBrandToUpdate);

            //assert
            _repository.Verify(x => x.Update(It.IsAny<CarType>()));
        }

        [Fact]
        public void CarTypeController_Delete_VerifyServiceIfWasCalled()
        {
            //arrange
            var carBrand = _suvVarType;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(It.IsAny<CarType>()));

            //act
            _service.Delete(carBrand);

            //assert
            _repository.Verify(r => r.Remove(carBrand));
        }

        [Fact]
        public void CarTypeController_DeleteById_VerifyIfServiceWasCalled()
        {
            //arrange
            var carBrand = _suvVarType;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(carBrand.Id));

            //act
            var controller = new CarTypeController(_service, _mapper);

            //act
            controller.Delete(carBrand.Id);

            //assert
            _repository.Verify(r => r.Remove(carBrand.Id));
        }

        [Fact]
        public void CarTypeController_FindById_ReturnsCarBrand()
        {
            //arrange
            var carBrandToGet = new CarTypeRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Title = "SUV"
            };

            _repository.Setup(x => x.FindById(carBrandToGet.Id));

            var controller = new CarTypeController(_service, _mapper);

            //act
            var result = controller.Get(carBrandToGet.Id);

            //assert
            _repository.Verify(r => r.FindById(carBrandToGet.Id));
        }


        [Fact]
        public void CarTypeController_GetAll_ReturnsList()
        {
            //arrange
            _repository.Setup(x => x.GetAll()).Returns(_carTypes);
            var controller = new CarTypeController(_service, _mapper);

            //act
            var actionResult = controller.Get();
            var result = actionResult;

            //assert
            Assert.Equal(_carTypes.Count, result.Count);
        }
    }
}