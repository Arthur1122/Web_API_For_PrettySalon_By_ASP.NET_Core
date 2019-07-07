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
    public class HairdresserRepository : IHairdresserRepository
    {
        private readonly RegisterContext _context;
        private readonly ILogger _logger;

        public HairdresserRepository(RegisterContext context, ILogger<HairdresserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<Hairdresser[]> GetAllHairdressers()
        {
            _logger.LogInformation("Getting all hairdressers");
            IQueryable<Hairdresser> query = _context.Hairdressers
                .Include(c => c.Salon);

            query = query.OrderBy(h => h.FirstName);
            return await query.ToArrayAsync();
        }

        public Hairdresser GetHairdresserById(int id)
        {
            IQueryable<Hairdresser> query = _context.Hairdressers
                .Include(c => c.Salon);

            query = query.Where(c => c.HairdresserId == id);
            return query.FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
