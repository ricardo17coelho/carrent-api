using Carrent.CarManagement.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Carrent.CarManagement.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CarManagement.Api
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
        public List<CarClassDto> Get()
        {
            return _service.GetAll().Select(car => _mapper.Map<CarClassDto>(car)).ToList();
        }

        [HttpGet("{id}")]
        public List<CarClassDto> Get(Guid id)
        {
            return _service.GetById(id).Select(car => _mapper.Map<CarClassDto>(car)).ToList();
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
        public void Post([FromBody] CarClassDto entity)
        {
            var c = _mapper.Map<CarClass>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarClassDto entity)
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
