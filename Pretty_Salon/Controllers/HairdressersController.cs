using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretty_Salon.Data;
using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;

namespace Pretty_Salon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairdressersController : ControllerBase
    {
        private readonly IHairdresserRepository _repository;
        private readonly ISalonRepository _salonRepository;
        private readonly IMapper _mapper;

        public HairdressersController(IHairdresserRepository repository,ISalonRepository salonRepository,IMapper mapper)
        {
            this._repository = repository;
            this._salonRepository = salonRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HairdresserModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllHairdressers();
                if (results == null) return NotFound();

                return _mapper.Map<HairdresserModel[]>(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<HairdresserModel> GetById([FromRoute] int id)
        {
            try
            {
                var result = _repository.GetHairdresserById(id);
                if (result == null) return NotFound("Could not found the hairdresser");

                return _mapper.Map<HairdresserModel>(result);
            }
            catch (Exception ez)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpPost]
        public async Task <ActionResult<HairdresserModel>> Post(HairdresserModel model)
        {
            try
            {
                var hairdresser = _mapper.Map<Hairdresser>(model);

                if (model.Salon == null) return BadRequest();
                var salon = await  _salonRepository.GetSalonByIdAsync(model.Salon.SalonId);
                if (salon == null) return NotFound();

                hairdresser.Salon = salon;

                _repository.Add(hairdresser);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<HairdresserModel>> Update(int id, HairdresserModel model)
        {
            try
            {
                var dresser = _repository.GetHairdresserById(id);
                if (dresser == null) return NotFound();

                _mapper.Map(model, dresser);

                if (model.Salon != null)
                {
                    var salon = await _salonRepository.GetSalonByIdAsync(model.Salon.SalonId);
                    if(salon != null)
                    {
                        dresser.Salon = salon;
                    }
                    
                }

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<HairdresserModel>(dresser);
                }
                else
                {
                    return _mapper.Map<HairdresserModel>(dresser);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var dresser = _repository.GetHairdresserById(id);
                if (dresser == null) return NotFound();

                _repository.Delete(dresser);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("failde to Delete Hairdresser");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }
    }
}