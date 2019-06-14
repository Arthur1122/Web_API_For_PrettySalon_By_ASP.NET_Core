using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly LinkGenerator _linkGenerator;

        public RegistrationsController(IRegistrationRepository repository,IMapper mapper,LinkGenerator linkGenerator)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
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

        [HttpGet("Single_Search")]
        public async Task<ActionResult<RegistrationModel>> Single_Search(DateTime theDate, string time)
        {
            try
            {
                var result = await _repository.GetRegistrationByDate_TimeAsync(theDate, time);
                if (result == null) return NotFound();

                return _mapper.Map<RegistrationModel>(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

    }
}