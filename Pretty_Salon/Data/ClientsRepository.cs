using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var client = new Client
            {
                FirstName = model.ClientFirstName,
                LastName =model.ClientLastName,
                Email = model.ClientEmail,
                PhoneNumber =model.ClientPhoneNumber
            };

            _context.Add(client);
            _context.SaveChanges();
            // ay stegh save changesic heto cliente kstana ira Idin, vorov hetev SaveChangese gruma baza u stanuma clienti IDn

            return client;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Client[]> GetAllClients()
        {
            IQueryable<Client> query = _context.Clients;

            return await query.ToArrayAsync();

        }

        public Client GetById(int id)
        {
            return _context.Find<Client>(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
