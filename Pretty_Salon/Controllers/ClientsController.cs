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
        public ClientsController(IClientsRespository clientsRespository)
        {
            _clientsRespository = clientsRespository;
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            try
            {
                var client = _clientsRespository.GetById(id);
                if (client == null) return NotFound();

                //obshi tenc anele sxala, arji veshni menak modelner veradarcnel voch te entityner
                return Ok(client);
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
    }
}
