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
                .ReverseMap();
            this.CreateMap<RegistrationModel, Registration>();

            this.CreateMap<Client, ClientModel>()
                .ForMember(c => c.ClientId, o => o.MapFrom(m => m.ClientId))
                .ForMember(c => c.ClientName, o => o.MapFrom(m => m.Name))
                .ReverseMap();

            this.CreateMap<ClientModel, Client>();

            this.CreateMap<Salon, SalonModel>()
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.SalonId))
                .ForMember(c => c.SalonName, o => o.MapFrom(m => m.Name))
                .ReverseMap();

            this.CreateMap<SalonModel, Salon>()
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.SalonId))
                .ForMember(c => c.Name, o => o.MapFrom(m => m.SalonName))
                .ReverseMap();
        }
    }
}
