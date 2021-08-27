using System;
using System.Collections.Generic;
using AutoMapper;
using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Domain;
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

        private readonly CarClass _luxuryClass = new()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 130,
            Type = "Luxury"
        };

        private readonly CarBrand _ferrariBrand = new()
        {
            Id = Guid.NewGuid(),
            Title = "Ferrari"
        };

        private readonly CarType _sportsType = new()
        {
            Id = Guid.NewGuid(),
            Title = "Sports"
        };

        private readonly Car _carSample01;
        private readonly Car _carSample02;


        private readonly List<Car> _cars;
        public TestCarBrandController()
        {
            _carSample01 = new()
            {
                Id = Guid.NewGuid(),
                Brand = _ferrariBrand,
                BrandId = _ferrariBrand.Id,
                Type = _sportsType,
                TypeId = _sportsType.Id,
                Class = _luxuryClass,
                ClassId = _luxuryClass.Id,
                Model = "California",
                Kilometers = 100,
                HorsePower = 1500,
                RegistrationYear = 2020
            };
 
            _carSample02 = new()
            {
                Id = Guid.NewGuid(),
                Brand = _ferrariBrand,
                BrandId = _ferrariBrand.Id,
                Type = _sportsType,
                TypeId = _sportsType.Id,
                Class = _luxuryClass,
                ClassId = _luxuryClass.Id,
                Model = "458",
                Kilometers = 200,
                HorsePower = 500,
                RegistrationYear = 2014
            };

            _cars = new List<Car>()
               {
                _carSample01,
                _carSample02
            };

            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<Car, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_cars);
            _repository.Setup(x => x.Insert(It.IsAny<Car>()));
            _repository.Setup(r => r.Remove(It.IsAny<Car>()));

            _service = new CarService(_repository.Object);
        }

        [Fact]
        public void CarController_Add_VerifyItemsIsAdded()
        {
            // arrange
            var controller = new CarController(_service, _mapper);
            var dto = new CarRequestCreateDto()
            {
                BrandId = _carSample01.BrandId,
                TypeId = _carSample01.TypeId,
                ClassId = _carSample01.ClassId,
                Model = _carSample01.Model,
                Kilometers = _carSample01.Kilometers,
                HorsePower = _carSample01.HorsePower,
                RegistrationYear = _carSample01.RegistrationYear
            };

            //act
            controller.Post(dto);

            //assert
            _repository.Verify(x => x.Insert(It.IsAny<Car>()));
        }

        //[Fact]
        //public void CarController_Edit_VerifyItemsIsUpdated()
        //{
        //    //arrange
        //    var dto = new CarRequestEditDto()
        //    {
        //        Id = _carSample02.Id,
        //        BrandId = _carSample02.BrandId,
        //        TypeId = _carSample02.TypeId,
        //        ClassId = _carSample02.ClassId,
        //        Model = _carSample02.Model,
        //        Kilometers = _carSample02.Kilometers,
        //        HorsePower = _carSample02.HorsePower,
        //        RegistrationYear = _carSample02.RegistrationYear
        //    };
        //    var controller = new CarController(_service, _mapper);
        //    _repository.Setup(r => r.Update(It.IsAny<Car>()));

        //    //act
        //    controller.Put(dto.Id, dto);

        //    //assert
        //    _repository.Verify(x => x.Update(It.IsAny<Car>()));
        //}

        [Fact]
        public void CustomerController_Delete_VerifyServiceIfWasCalled()
        {
            //arrange
            var model = _carSample01;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(It.IsAny<Car>()));

            //act
            _service.Delete(model);

            //assert
            _repository.Verify(r => r.Remove(model));
        }

        [Fact]
        public void CustomerController_DeleteById_VerifyIfServiceWasCalled()
        {
            //arrange
            var model = _carSample01;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(model.Id));

            //act
            var controller = new CarController(_service, _mapper);

            //act
            controller.Delete(model.Id);

            //assert
            _repository.Verify(r => r.Remove(model.Id));
        }

        [Fact]
        public void CustomerController_FindById_ReturnsCustomer()
        {
            //arrange
            var dto = new CarRequestEditDto()
            {
                Id = Guid.NewGuid(),
                BrandId = Guid.NewGuid(),
                TypeId = Guid.NewGuid(),
                ClassId = Guid.NewGuid(),
                Model = "458",
                Kilometers = 200,
                HorsePower = 500,
                RegistrationYear = 2014
            };

            _repository.Setup(x => x.FindById(dto.Id));

            var controller = new CarController(_service, _mapper);

            //act
            var result = controller.Get(dto.Id);

            //assert
            _repository.Verify(r => r.FindById(dto.Id));
        }


        [Fact]
        public void CustomerController_GetAll_ReturnsList()
        {
            //arrange
            _repository.Setup(x => x.GetAll()).Returns(_cars);
            var controller = new CarController(_service, _mapper);

            //act
            var actionResult = controller.Get();
            var result = actionResult;

            //assert
            Assert.Equal(_cars.Count, result.Count);
        }
    }
}