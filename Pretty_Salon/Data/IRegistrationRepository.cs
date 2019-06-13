using Pretty_Salon.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public interface IRegistrationRepository
    {
        //General
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Registrations
        Task<Registration[]> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByNameAsync(string name);
        Task<Registration[]> GetAllRegistrationsByDateAsync(DateTime dateTime);

        //Clients
        Task<Client[]> GetAllClientsAsync();
        Task<Client> GetClientByNameAsync(string name);

        //Hairdressers
        Task<Hairdresser[]> GetAllHairdressersAsync();
        Task<Hairdresser> GetHairdresserByNameAsync(string name);

        //Salons
        Task<Salon[]> GetAllSalonsAsync();
        Task<Salon> GetSalonByNameAsync(string name);

    }
}
