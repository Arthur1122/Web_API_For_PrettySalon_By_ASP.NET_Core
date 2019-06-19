using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Pretty_Salon.Data;
using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;

namespace Pretty_Salon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly ISalonRepository _repository;

        public SalonsController(ISalonRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<SalonModel>> GetById(int id)
        {
            try
            {
                var salon = await _repository.GetSalonByIdAsync(id);
                if (salon == null) return NotFound();

                return _mapper.Map<SalonModel>(salon);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public ActionResult<SalonModel> Post(SalonModel model)
        {
            try
            {

                var uri = _linkGenerator.GetPathByAction(HttpContext,
                    "Get",
                    values: new { name = model.SalonName });

                if (string.IsNullOrWhiteSpace(uri))
                {
                    return BadRequest("Could not use current name");
                }

                var salon = _repository.Create(model);
                if (_repository.SaveChangesAsync())
                {
                    return Created(uri, _mapper.Map<SalonModel>(salon));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPut]
        public async Task<ActionResult<SalonModel>> Update(int id,SalonModel model)
        {
            try
            {
                var oldSalon = await _repository.GetSalonByIdAsync(id);
                var res = _mapper.Map(model,oldSalon);
                _repository.SaveChangesAsync();
                
                return _mapper.Map<SalonModel>(res);
                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}