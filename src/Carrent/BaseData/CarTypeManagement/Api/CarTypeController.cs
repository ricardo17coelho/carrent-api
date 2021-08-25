using AutoMapper;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Models;
using Carrent.BaseData.CarTypesManagement.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.BaseData.CarTypesManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeService _service;
        private readonly IMapper _mapper;

        public CarTypeController(ICarTypeService carTypeService, IMapper mapper)
        {
            _service = carTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public List<CarTypeResponseDto> Get()
        {
            return _service.GetAll().Select(carType => _mapper.Map<CarTypeResponseDto>(carType)).ToList();
        }

        [HttpGet("{id}")]
        public CarTypeRequestEditDto Get(Guid id)
        {
            CarType carType = _service.GetById(id);
            return _mapper.Map<CarTypeRequestEditDto>(carType);
        }

        [HttpPost]
        public void Post([FromBody] CarTypeRequestCreateDto entity)
        {
            var c = _mapper.Map<CarType>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarTypeRequestEditDto entity)
        {
            entity.Id = id;
            var c = _mapper.Map<CarType>(entity);
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        { 
            _service.DeleteById(id);
        }
    }
}
