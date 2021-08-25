using AutoMapper;
using Carrent.ReservationManagement.Application;
using Carrent.ReservationManagement.Domain;
using Carrent.ReservationManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.ReservationManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ReservationResponseDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<ReservationResponseDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public ReservationResponseDto Get(Guid id)
        {
            Reservation reservation = _service.GetById(id);
            return _mapper.Map<ReservationResponseDto>(reservation);
        }

        [HttpPost]
        public void Post([FromBody] ReservationRequestCreateDto entity)
        {
            var c = _mapper.Map<Reservation>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ReservationRequestEditDto entity)
        {
            var c = _mapper.Map<Reservation>(entity);
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
