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
    public class HairdressersController : ControllerBase
    {
        private readonly IHairdresserRepository _repository;
        private readonly IMapper _mapper;

        public HairdressersController(IHairdresserRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HairdresserGetModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllHairdressers();
                if (results == null) return NotFound();

                return _mapper.Map<HairdresserGetModel[]>(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }
    }
}