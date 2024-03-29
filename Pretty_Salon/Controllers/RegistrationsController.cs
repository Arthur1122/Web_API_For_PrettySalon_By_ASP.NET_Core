﻿using System;
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
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationRepository _repository;
        private readonly IClientsRespository _clientsRespository;
        private readonly ISalonRepository _salonRepository;
        private readonly IHairdresserRepository _hairdresserRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public RegistrationsController(IRegistrationRepository repository, IClientsRespository clientsRespository,
                                       ISalonRepository salonRepository, IHairdresserRepository hairdresserRepository,
                                       IMapper mapper, LinkGenerator linkGenerator)
        {
            this._repository = repository;
            this._clientsRespository = clientsRespository;
            this._salonRepository = salonRepository;
            this._hairdresserRepository = hairdresserRepository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<RegistrationModel[]>> Get()
        {
            try
            {
                var registrations = await _repository.GetAllRegistrationsAsync();
                if (registrations == null) return NotFound();

                return _mapper.Map<RegistrationModel[]>(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RegistrationModel> GetById([FromRoute]int id)
        {
            try
            {
                var register = _repository.GetRegistrationById(id);
                if (register == null) return NotFound();
                return  _mapper.Map<RegistrationModel>(register);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpGet("{theDate}")]
        public async Task<ActionResult<RegistrationModel[]>> Search(DateTime theDate)
        {
            try
            {
                var results = await _repository.GetRegistrationsByDateAsync(theDate);
                if (!results.Any()) return NotFound();

                return _mapper.Map<RegistrationModel[]>(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpGet("{theDate}/{time}")]
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

        [HttpPost]
        public async Task<ActionResult<RegistrationModel>> Post(RegistrationModel model)
        {
            try
            {
                var exist = await _repository.GetRegistrationByDate_TimeAsync(model.Day, model.TimeOfDay);
                if (exist != null) return BadRequest("The registration in use");

                var url = _linkGenerator.GetPathByAction("Get",
                    "Registrations",
                    new { Day = model.Day, TimeOfDay = model.TimeOfDay });

                if (string.IsNullOrWhiteSpace(url))
                {
                    return BadRequest("Could not use current Day and Time");
                }

                Registration registration = _mapper.Map<Registration>(model);
                if (model.ClientId != 0)
                {
                    var client = _clientsRespository.GetById(model.ClientId);
                    if (client == null) return NotFound();

                    registration.Client = client;
                }
                if (model.HairdresserId != 0)
                {
                    var dresser = _hairdresserRepository.GetHairdresserById(model.HairdresserId);
                    if (dresser == null) return NotFound();
                    registration.Hairdresser = dresser;
                }
                if (model.SalonId != 0)
                {
                    var salon = await _salonRepository.GetSalonByIdAsync(model.SalonId);
                    if (salon == null) return NotFound();
                    registration.Salon = salon;
                }

                _repository.Add(registration);

                if (await _repository.SaveChangesAsync())
                {
                    return Created(url, _mapper.Map<RegistrationModel>(registration));
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
        public async Task<ActionResult<RegistrationModel>> Update(int id, RegistrationModel model)
        {
            try
            {
                var register = _repository.GetRegistrationById(id);
                if (register == null) return NotFound();

                _mapper.Map(model, register);

                if (model.ClientId != 0)
                {
                    var client = _clientsRespository.GetById(model.ClientId);
                    if (client == null) return NotFound();

                    register.Client = client;
                }
                if (model.HairdresserId != 0)
                {
                    var dresser = _hairdresserRepository.GetHairdresserById(model.HairdresserId);
                    if (dresser == null) return NotFound();
                    register.Hairdresser = dresser;
                }
                if (model.SalonId != 0)
                {
                    var salon = await _salonRepository.GetSalonByIdAsync(model.SalonId);
                    if (salon == null) return NotFound();
                    register.Salon = salon;
                }
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<RegistrationModel>(register);
                }
                else
                {
                    return _mapper.Map<RegistrationModel>(register);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<RegistrationModel>> Delete(int id)
        {
            try
            {
                var regiter = _repository.GetRegistrationById(id);
                if (regiter == null) return NotFound();
                _repository.Delete(regiter);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("failed to Delete Hairdresser");
                }
            }
            catch (Exception ex )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }
    }
}