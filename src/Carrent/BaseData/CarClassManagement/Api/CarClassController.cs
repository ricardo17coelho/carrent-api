using Carrent.BaseData.CarClassManagement.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Carrent.BaseData.CarClassManagement.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.BaseData.CarClassManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _service;
        private readonly IMapper _mapper;

        public CarClassController(ICarClassService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarClassResponseDto> Get()
        {
            return _service.GetAll().Select(car => _mapper.Map<CarClassResponseDto>(car)).ToList();
        }

        [HttpGet("{id}")]
        public List<CarClassResponseDto> Get(Guid id)
        {
            return _service.GetById(id).Select(car => _mapper.Map<CarClassResponseDto>(car)).ToList();
        }
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Following Types are allowed
        /// Classic,
        /// Basic,
        /// Medium,
        /// Luxury
        /// </remarks>
        /// <param name="entity"></param>
        [HttpPost]
        public void Post([FromBody] CarClassRequestCreateDto entity)
        {
            var c = _mapper.Map<CarClass>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarClassRequestEditDto entity)
        {
            entity.Id = id;
            var c = _mapper.Map<CarClass>(entity);
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
