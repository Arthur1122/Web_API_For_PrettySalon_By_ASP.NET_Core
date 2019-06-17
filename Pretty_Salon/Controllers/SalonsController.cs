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
    public class SalonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISalonRepository _repository;

        public SalonsController(ISalonRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public  ActionResult<SalonModel[]> Get()
        {
            try
            {
                var results =  _repository.GetAllSalons();
                if (results == null) return NotFound();

                return  _mapper.Map<SalonModel[]>(results);
            }
            catch (Exception  ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Database Failure");
            }
        }

    }
}