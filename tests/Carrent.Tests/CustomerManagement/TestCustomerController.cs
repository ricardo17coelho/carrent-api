using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Carrent.Common.Interfaces;
using Carrent.Common.Mapper;
using Carrent.CustomerManagement.Api;
using Carrent.CustomerManagement.Application;
using Carrent.CustomerManagement.Domain;
using Carrent.CustomerManagement.Models;
using Moq;
using Xunit;

namespace CarRent.Test.CustomerManagement
{
    public class TestCustomerController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        private readonly Mock<IRepository<Customer, Guid>> _repository;

        private readonly Customer _customerJoe = new()
        {
            Id = Guid.NewGuid(),
            Firstname = "Joe",
            Lastname = "Doe",
            Street = "Fakestreet 1",
            Country = "CH",
            Town = "St. Gallen",
            Zip = "9000"
        };
        private readonly Customer _customerThomas = new()
        {
            Id = Guid.NewGuid(),
            Firstname = "Thomas",
            Lastname = "Schmit",
            Street = "Fakestreet 1",
            Country = "CH",
            Town = "St. Gallen",
            Zip = "9000"
        };
        private readonly Customer _customerHans= new()
        {
            Id = Guid.NewGuid(),
            Firstname = "Hans",
            Lastname = "Mueller",
            Street = "Fakestreet 1",
            Country = "CH",
            Town = "St. Gallen",
            Zip = "9000"
        };

        private readonly List<Customer> _customers;
        public TestCustomerController()
        {

            var carClasses = new List<Customer>()
            {
                _customerJoe ,
                _customerThomas,
                _customerHans
            };
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    Firstname = "Hans",
                    Lastname = "Mueller",
                    Street = "Fakestreet 1",
                    Country = "CH",
                    Town = "St. Gallen",
                    Zip = "9000"
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CustomerProfile));
            }));

            _repository = new Mock<IRepository<Customer, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_customers);
            _repository.Setup(x => x.Insert(It.IsAny<Customer>()));

            _service = new CustomerService(_repository.Object);
        }


        [Fact]
        public void CustomerController_Add_VerifyItemsIsAdded()
        {
            // arrange
            var controller = new CustomerController(_service, _mapper);
            var dto = new CustomerRequestCreateDto()
            {
                Firstname = "Ricardo",
                Lastname = "Coelho",
                Street = "Gaiserwaldstrasse 6",
                Zip = "9015",
                Country = "CH",
                Town = "St. Gallen"
            };

            //act
            controller.Post(dto);

            //assert
            _repository.Verify(x => x.Insert(It.IsAny<Customer>()));
        }

        [Fact]
        public void CustomerController_Edit_VerifyItemsIsUpdated()
        {
            //arrange
            var dto = new CustomerRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Firstname = "Ricardo",
                Lastname = "Coelho",
                Street = "Gaiserwaldstrasse 6",
                Zip = "9015",
                Country = "CH",
                Town = "St. Gallen"
            };
            var controller = new CustomerController(_service, _mapper);

            //act
            controller.Put(dto.Id, dto);

            //assert
            _repository.Verify(x => x.Update(It.IsAny<Customer>()));
        }

        [Fact]
        public void CustomerController_Delete_VerifyServiceIfWasCalled()
        {
            //arrange
            var model = _customerJoe;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(It.IsAny<Customer>()));

            //act
            _service.Delete(model);

            //assert
            _repository.Verify(r => r.Remove(model));
        }

        [Fact]
        public void CustomerController_DeleteById_VerifyIfServiceWasCalled()
        {
            //arrange
            var model = _customerJoe;

            //set up the repository’s Delete call
            _repository.Setup(r => r.Remove(model.Id));

            //act
            var controller = new CustomerController(_service, _mapper);

            //act
            controller.Delete(model.Id);

            //assert
            _repository.Verify(r => r.Remove(model.Id));
        }

        [Fact]
        public void CustomerController_FindById_ReturnsCustomer()
        {
            //arrange
            var dto = new CustomerRequestEditDto()
            {
                Id = Guid.NewGuid(),
                Firstname = "Ricardo",
                Lastname = "Coelho",
                Street = "Gaiserwaldstrasse 6",
                Zip = "9015",
                Country = "CH",
                Town = "St. Gallen"
            };

            _repository.Setup(x => x.FindById(dto.Id));

            var controller = new CustomerController(_service, _mapper);

            //act
            var result = controller.Get(dto.Id);

            //assert
            _repository.Verify(r => r.FindById(dto.Id));
        }


        [Fact]
        public void CustomerController_GetAll_ReturnsList()
        {
            //arrange
            _repository.Setup(x => x.GetAll()).Returns(_customers);
            var controller = new CustomerController(_service, _mapper);

            //act
            var actionResult = controller.Get();
            var result = actionResult;

            //assert
            Assert.Equal(_customers.Count, result.Count);
        }
    }
}