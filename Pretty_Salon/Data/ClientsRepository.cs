using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;

namespace Pretty_Salon.Data
{
    public class ClientsRepository : IClientsRespository
    {
        private readonly RegisterContext _context;
        private readonly ILogger _logger;

        public ClientsRepository(RegisterContext context, ILogger<ClientsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Client Create(ClientModel model)
        {
            var client = new Client { Name = model.ClientName };

            _context.Add(client);
            _context.SaveChanges();
            // ay stegh save changesic heto cliente kstana ira Idin, vorov hetev SaveChangese gruma baza u stanuma clienti IDn

            return client;
        }

        public Client GetById(int id)
        {
            return _context.Find<Client>(id);
        }
    }
}
