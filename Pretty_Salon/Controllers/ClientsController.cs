using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretty_Salon.Data;
using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRespository _clientsRespository;
        private readonly IMapper _mapper;

        public ClientsController(IClientsRespository clientsRespository,IMapper mapper)
        {
            this._clientsRespository = clientsRespository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ClientModel[]>> Get()
        {
            try
            {
                var clients = await _clientsRespository.GetAllClients();
                if (clients == null) return BadRequest();

                return Ok( _mapper.Map<ClientModel[]>(clients));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClientModel> GetById([FromRoute]int id)
        {
            try
            {
                var client = _clientsRespository.GetById(id);
                if (client == null) return NotFound();

                return Ok(_mapper.Map<ClientModel>(client));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpPost]
        public ActionResult Post(ClientModel model)
        {
            try
            {
                var res = _clientsRespository.Create(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpPut]
        public ActionResult Update(int id, ClientModel model)
        {
            try
            {
                var oldClient = _clientsRespository.GetById(id);
                if (oldClient == null) return NotFound();

                oldClient.Name = model.ClientName;

                _clientsRespository.SaveChanges();
                return Ok(oldClient);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }
        }

        [HttpDelete("{id}")]
        public  ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var result =  _clientsRespository.GetById(id);
                if (result == null) return NotFound("Could not found that id");

                _clientsRespository.Delete(result);
                if ( _clientsRespository.SaveChanges())
                {
                    return Ok();
                }
            }
            catch (Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed database");
            }

            return BadRequest();
        }

    }
}
