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
    public class SalonRepository : ISalonRepository
    {
        private readonly RegisterContext _context;
        private readonly ILogger<SalonRepository> _logger;

        public SalonRepository(RegisterContext context, ILogger<SalonRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public Salon Create(SalonModel model)
        {
            _logger.LogInformation("Create new Salon entity");
            Salon salon = new Salon
            {
                Name = model.SalonName,
                Address = model.SalonAddress,
                PhoneNumber = model.SalonPhoneNumber
            };
            _context.Add(salon);
            return salon;
        }

        public void Delete(Salon salon)
        {
            _logger.LogInformation("Delete Salon entity from database");
            _context.Remove(salon);
        }

        public Salon[] GetAllSalons()
        {
            _logger.LogInformation("Get all salons");
            IQueryable<Salon> query = _context.Salons;
            return query.ToArray();
        }

        public async Task<Salon> GetSalonByIdAsync(int id)
        {
            _logger.LogInformation("Get salon by Id");

            IQueryable<Salon> query = _context.Salons;
            query = query.Where(c => c.SalonId == id);

            return await query.FirstOrDefaultAsync();
        }
        public bool SaveChangesAsync()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
