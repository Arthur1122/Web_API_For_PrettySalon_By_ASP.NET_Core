using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public interface IHairdresserRepository
    {
        Task<Hairdresser[]> GetAllHairdressers();
        Hairdresser GetHairdresserById(int id);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
