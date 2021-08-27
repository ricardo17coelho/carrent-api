using AutoMapper;
using Carrent.BaseData.CarClassManagement.Api;
using Carrent.BaseData.CarClassManagement.Application;
using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Carrent.Tests.BaseData.CarClassManagement
{
    public class TestCarClassController
    {
        public class TestCarTypeController
        {
            private readonly IMapper _mapper;
            private readonly ICarClassService _service;

            private readonly Mock<IRepository<CarClass, Guid>> _repository;

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

            private readonly List<CarClass> _carClasses;
            public TestCarTypeController()
            {

                var carClasses = new List<CarClass>()
            {
                _basicClass,
                _mediumClass,
                _luxuryClass
            };
            _carClasses = new List<CarClass>()
                {
                    new CarClass()
                    {
                        Id = Guid.NewGuid(),
                        PricePerDay = 130,
                        Type = "Luxury"
                    }
                };
                _mapper = new Mapper(new MapperConfiguration(conf =>
                {
                    conf.AddProfile(typeof(CarProfile));
                }));

                _repository = new Mock<IRepository<CarClass, Guid>>();

                _repository.Setup(x => x.GetAll()).Returns(_carClasses);
                _repository.Setup(x => x.Insert(It.IsAny<CarClass>()));

                _service = new CarClassService(_repository.Object);
            }

            [Fact]
            public void CarClassController_Add_VerifyItemsIsAdded()
            {
                // arrange
                var controller = new CarClassController(_service, _mapper);
                var carBrandToAdd = new CarClassRequestCreateDto()
                {
                    PricePerDay = 130,
                    Type = "Luxury"
                };

                //act
                controller.Post(carBrandToAdd);

                //assert
                _repository.Verify(x => x.Insert(It.IsAny<CarClass>()));
            }

            [Fact]
            public void CarClassController_Edit_VerifyItemsIsUpdated()
            {
                //arrange
                var carBrandToUpdate = new CarClassRequestEditDto()
                {
                    Id = Guid.NewGuid(),
                    PricePerDay = 130,
                    Type = "Luxury"
                };
                var controller = new CarClassController(_service, _mapper);

                //act
                controller.Put(carBrandToUpdate.Id, carBrandToUpdate);

                //assert
                _repository.Verify(x => x.Update(It.IsAny<CarClass>()));
            }

            [Fact]
            public void CarClassController_Delete_VerifyServiceIfWasCalled()
            {
                //arrange
                var carBrand = _luxuryClass;

                //set up the repository’s Delete call
                _repository.Setup(r => r.Remove(It.IsAny<CarClass>()));

                //act
                _service.Delete(carBrand);

                //assert
                _repository.Verify(r => r.Remove(carBrand));
            }

            [Fact]
            public void CarClassController_DeleteById_VerifyIfServiceWasCalled()
            {
                //arrange
                var carBrand = _luxuryClass;

                //set up the repository’s Delete call
                _repository.Setup(r => r.Remove(carBrand.Id));

                //act
                var controller = new CarClassController(_service, _mapper);

                //act
                controller.Delete(carBrand.Id);

                //assert
                _repository.Verify(r => r.Remove(carBrand.Id));
            }

            [Fact]
            public void CarClassController_FindById_ReturnsCarBrand()
            {
                //arrange
                var carBrandToGet = new CarClassRequestEditDto()
                {
                    PricePerDay = 130,
                    Type = "Luxury"
                };

                _repository.Setup(x => x.FindById(carBrandToGet.Id));

                var controller = new CarClassController(_service, _mapper);

                //act
                var result = controller.Get(carBrandToGet.Id);

                //assert
                _repository.Verify(r => r.FindById(carBrandToGet.Id));
            }


            [Fact]
            public void CarClassController_GetAll_ReturnsList()
            {
                //arrange
                _repository.Setup(x => x.GetAll()).Returns(_carClasses);
                var controller = new CarClassController(_service, _mapper);

                //act
                var actionResult = controller.Get();
                var result = actionResult;

                //assert
                Assert.Equal(_carClasses.Count, result.Count);
            }
        }
    }
}
