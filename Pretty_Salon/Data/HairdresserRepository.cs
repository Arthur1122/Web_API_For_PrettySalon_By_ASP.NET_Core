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

        public Hairdresser Create(HairdresserGetModel model)
        {
            _logger.LogInformation("Creating a Hairdresser");
            var hairdresser = new Hairdresser { Name = model.HairdresserName };
            _context.Add(hairdresser);
            _context.SaveChanges();
            return hairdresser;
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation("Deleting the entity");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Hairdresser[]> GetAllHairdressers()
        {
            _logger.LogInformation("Getting all hairdressers");
            IQueryable<Hairdresser> query = _context.Hairdressers
                .Include(c => c.Salon);

            query = query.OrderBy(h => h.Name);
            return await query.ToArrayAsync();
        }

        public Hairdresser GetHairdresserById(int id)
        {
            return _context.Find<Hairdresser>(id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
