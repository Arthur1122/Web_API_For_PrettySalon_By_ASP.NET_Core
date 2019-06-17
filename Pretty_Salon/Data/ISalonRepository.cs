﻿using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public interface ISalonRepository
    {
        void Delete(Salon salon);
        bool SaveChangesAsync();

        Salon[] GetAllSalons();
        Salon GetSalonById(int id);
        Salon GetSalonByName(string name);
        Salon Create(SalonModel model);
    }
}