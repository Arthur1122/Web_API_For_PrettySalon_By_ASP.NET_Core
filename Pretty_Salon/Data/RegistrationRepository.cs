using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pretty_Salon.Data.Entities;

namespace Pretty_Salon.Data
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly RegisterContext _context;
        private readonly ILogger _logger;

        public RegistrationRepository(RegisterContext context, ILogger<RegistrationRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} in the context");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Client[]> GetAllClientsAsync()
        {
            _logger.LogInformation($"Getting all Clients");

            IQueryable<Client> query = _context.Clients;

            return await query.ToArrayAsync();
        }

        public async Task<Client> GetClientByNameAsync(string name)
        {
            _logger.LogInformation($"Getting a Client for {name}");

            IQueryable<Client> query = _context.Clients;

            query = query.Where(c => c.Name == name);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<Hairdresser[]> GetAllHairdressersAsync()
        {
            _logger.LogInformation($"Getting all Hairdressers");

            IQueryable<Hairdresser> query = _context.Hairdressers
                .Include(c => c.Salon);

            return await query.ToArrayAsync();
        }

        public async Task<Hairdresser> GetHairdresserByNameAsync(string name)
        {
            _logger.LogInformation($"Getting a Hairdresser for {name}");

            IQueryable<Hairdresser> query = _context.Hairdressers
                .Include(c => c.Salon);

            query = query.Where(c => c.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Registration[]> GetAllRegistrationsAsync()
        {
            _logger.LogInformation($"Getting all Registrations");

            IQueryable<Registration> query = _context.Registrations
                .Include(c => c.Client)
                .Include(n => n.Hairdresser)
                .Include(k => k.Salon);

            query = query.OrderByDescending(c => c.Day);

            return await query.ToArrayAsync();
        }

        public async Task<Registration[]> GetRegistrationsByDateAsync(DateTime dateTime)
        {
            _logger.LogInformation($"Getting a Registration for {dateTime}");

            IQueryable<Registration> query = _context.Registrations
                .Include(c => c.Client)
                .Include(n => n.Hairdresser)
                .Include(k => k.Salon);

            query = query.Where(c => c.Day == dateTime).OrderByDescending(m => m.Day);

            return await query.ToArrayAsync();
        }
        public Task<Registration> GetRegistrationByDate_TimeAsync(DateTime dateTime, string time)
        {
            _logger.LogInformation($"Get a Registration by {dateTime} and {time}");

            IQueryable<Registration> query = _context.Registrations
                .Include(c => c.Client)
                .Include(n => n.Hairdresser)
                .Include(k => k.Salon);

            query = query.Where(c => c.Day == dateTime);
            query = query.Where(c => c.TimeOfDay == time);

            return query.FirstOrDefaultAsync();
        }
        public async Task<Salon[]> GetAllSalonsAsync()
        {
            _logger.LogInformation($"Getting all Salons");

            IQueryable<Salon> query = _context.Salons;

            return await query.ToArrayAsync();
        }
        public async Task<Salon> GetSalonByNameAsync(string name)
        {
            _logger.LogInformation($"Getting a salon for {name}");

            IQueryable<Salon> query = _context.Salons;

            query = query.Where(c => c.Name == name);

            return await query.FirstOrDefaultAsync();
        }


    }
}
