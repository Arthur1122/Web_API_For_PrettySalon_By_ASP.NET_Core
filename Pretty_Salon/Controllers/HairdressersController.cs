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

        [HttpGet("{id}")]
        public ActionResult<HairdresserGetModel> GetById([FromRoute] int id)
        {
            try
            {
                var result = _repository.GetHairdresserById(id);
                if (result == null) return NotFound("Could not found the hairdresser");

                return _mapper.Map<HairdresserGetModel>(result);
            }
            catch (Exception ez)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }
    }
}