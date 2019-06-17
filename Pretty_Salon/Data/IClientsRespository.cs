using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public interface IClientsRespository
    {
        Task <Client[]> GetAllClients();
        Client GetById(int id);
        Client Create(ClientModel model);
        void Delete<T>(T entity) where T : class; 
        bool SaveChanges();
    }
}
