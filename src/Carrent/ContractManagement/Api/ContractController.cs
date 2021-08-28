using AutoMapper;
using Carrent.ContractManagement.Application;
using Carrent.ContractManagement.Domain;
using Carrent.ContractManagement.Infrastructure.Exceptions;
using Carrent.ContractManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.ContractManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _service;
        private readonly IMapper _mapper;

        public ContractController(IContractService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RentalContractResponseDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<RentalContractResponseDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RentalContractResponseDto> Get(Guid id)
        {
            RentalContract rentalContract = _service.GetById(id);
            return _mapper.Map<RentalContractResponseDto>(rentalContract);
        }


        [HttpPost]
        public ActionResult<RentalContractResponseDto> Post(RentalContractRequestCreateDto entity)
        {
            try
            {
                var c = _mapper.Map<RentalContract>(entity);
                var obj =  _service.Add(c);
                return _mapper.Map<RentalContractResponseDto>(obj);
            }
            catch (NotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "Reservation not Found");
            }            
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }

        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] RentalContractRequestEditDto entity)
        {
            var c = _mapper.Map<RentalContract>(entity);
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
