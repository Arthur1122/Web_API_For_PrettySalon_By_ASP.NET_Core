using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretty_Salon.Data;
using Pretty_Salon.Models;

namespace Pretty_Salon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationRepository _repository;
        private readonly IMapper _mapper;

        public RegistrationsController(IRegistrationRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public  async Task<ActionResult<RegistrationModel[]>> Get()
        {
            try
            {
                var registrations = await _repository.GetAllRegistrationsAsync();
                if (registrations == null) return NotFound();

                return _mapper.Map<RegistrationModel[]>(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Failed database");
            }
        }
        [HttpGet("Search")]
        public async Task<ActionResult<RegistrationModel[]>> Search(DateTime dateTime)
        {
            try
            {
                var results = await _repository.GetRegistrationsByDateAsync(dateTime);
                if (!results.Any()) return NotFound();

                return _mapper.Map<RegistrationModel[]>(results);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }
    }
}