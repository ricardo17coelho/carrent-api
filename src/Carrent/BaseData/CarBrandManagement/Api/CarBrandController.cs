using AutoMapper;
using Carrent.BaseData.CarBrandManagement.Application;
using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarBrandManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.BaseData.CarBrandManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _service;
        private readonly IMapper _mapper;

        public CarBrandController(ICarBrandService carBrandService, IMapper mapper)
        {
            _service = carBrandService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarBrandResponseDto> Get()
        {
            return _service.GetAll().Select(carBrand => _mapper.Map<CarBrandResponseDto>(carBrand)).ToList();
        }

        [HttpGet("{id}")]
        public List<CarBrandRequestEditDto> Get(Guid id)
        {
            return _service.GetById(id).Select(carBrand => _mapper.Map<CarBrandRequestEditDto>(carBrand)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] CarBrandRequestCreateDto entity)
        {
            var c = _mapper.Map<CarBrand>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarBrandRequestEditDto entity)
        {
            entity.Id = id;
            var c = _mapper.Map<CarBrand>(entity);
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
