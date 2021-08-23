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


        private readonly List<Customer> _entities;
        public TestCustomerController()
        {


            _entities = new List<Customer>()
            {
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "asd",
                    Lastname = "asdf",
                    Street = "asdf",
                    Country = "Switzerland",
                    Town = "Hansel",
                    Zip = "90123"
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CustomerProfile));
            }));

            _repository = new Mock<IRepository<Customer, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_entities);
            _repository.Setup(x => x.Insert(It.IsAny<Customer>()));

            _service = new CustomerService(_repository.Object);
        }

        //[Fact]
        //public void TestGetAll()
        //{
        //    var controller = new CustomerController(_service, _mapper);

        //    var result = controller.Get();

        //    result.Should().NotBeEmpty().And.BeEquivalentTo(_entities, o => o.ExcludingMissingMembers());
        //}

        [Fact]
        public void TestAdd()
        {
            var controller = new CustomerController(_service, _mapper);

            var entityToAdd = new CustomerRequestCreateDto()
            {
                Firstname = "Ricardo",
                Lastname = "Coelho",
                Street = "Gaiserwaldstrasse 6",
                Zip = "9015",
                Country = "CH",
                Town = "St. Gallen"
            };

            controller.Post(entityToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Customer>()));
        }
    }
}