using AutoMapper;
using Pretty_Salon.Data.Entities;
using Pretty_Salon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            this.CreateMap<Registration, RegistrationModel>()
                .ForMember(c => c.TimeOfDay, o => o.MapFrom(n => n.TimeOfDay))
                .ReverseMap();
            this.CreateMap<RegistrationModel, Registration>()
                .ReverseMap();
        }
    }
}
