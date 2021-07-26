using AutoMapper;
using Carrent.ZipCodeManagement.Application;
using Carrent.ZipCodeManagement.Domain;
using Carrent.ZipCodeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.ZipCodeManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        private readonly IZipCodeService _service;
        private readonly IMapper _mapper;

        public ZipCodeController(IZipCodeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ZipCodeDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<ZipCodeDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public List<ZipCodeDto> Get(Guid id)
        {
            return _service.GetById(id).Select(entity => _mapper.Map<ZipCodeDto>(entity)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] ZipCodeDto entity)
        {
            var c = _mapper.Map<ZipCode>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ZipCodeDto entity)
        {
            var c = _mapper.Map<ZipCode>(entity);
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
