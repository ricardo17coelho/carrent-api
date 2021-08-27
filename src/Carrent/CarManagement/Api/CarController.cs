using AutoMapper;
using Carrent.CarManagement.Application;
using Carrent.CarManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        ///  
        ///     POST /Todo
        ///     {
        ///        "key": "0e7ad584-7788-4ab1-95a6-ca0a5b444cbb",
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        /// 
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>New Created Todo Item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        public List<CarResponseDto> Get()
        {
            return _carService.GetAll().Select(car => _mapper.Map<CarResponseDto>(car)).ToList();
        }

        /// <summary>
        /// Get car by id
        /// </summary>
        [HttpGet("{id}")]
        public CarResponseDto Get(Guid id)
        {
            Car car = _carService.GetById (id);
            return _mapper.Map<CarResponseDto>(car);
        }

        [HttpGet("search/{searchTerm}")]
        public List<CarResponseDto> Search(string searchTerm)
        {
            return _carService.GetAll()
                //.Where(x => x.BrandId.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) || x.Type.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => _mapper.Map<CarResponseDto>(x)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] CarRequestCreateDto car)
        {
            var carMapped = _mapper.Map<Car>(car);
            _carService.Add(carMapped);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarRequestEditDto car)
        {
            car.Id = id;
            var c = _mapper.Map<Car>(car);
            _carService.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _carService.DeleteById(id);
        }
    }
}
