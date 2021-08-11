using AutoMapper;
using Carrent.CustomerManagement.Application;
using Carrent.CustomerManagement.Domain;
using Carrent.CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CustomerManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CustomerResponseDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<CustomerResponseDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public List<CustomerResponseDto> Get(Guid id)
        {
            return _service.GetById(id).Select(entity => _mapper.Map<CustomerResponseDto>(entity)).ToList();
        }

        [HttpGet("search/{searchTerm}")]
        public List<CustomerResponseDto> Search(string searchTerm)
        {
            return _service.GetAll()
                .Where(x => x.Firstname.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) || x.Lastname.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => _mapper.Map<CustomerResponseDto>(x)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] CustomerRequestCreateDto entity)
        {
            var c = _mapper.Map<Customer>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerRequestEditDto entity)
        {
            var c = _mapper.Map<Customer>(entity);
            c.Id = id;
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
