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
                .ForMember(c=>c.RegistrrationId,o=>o.MapFrom(m=>m.RegistrationId))
                .ForMember(c => c.ClientId, o => o.MapFrom(m => m.Client.ClientId))
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.Salon.SalonId))
                .ForMember(c => c.HairdresserId, o => o.MapFrom(m => m.Hairdresser.HairdresserId))
                .ReverseMap();
            this.CreateMap<RegistrationModel, Registration>()
                .ForPath(c => c.Client.ClientId, o => o.MapFrom(m => m.ClientId))
                .ForPath(c => c.Salon.SalonId, o => o.MapFrom(m => m.SalonId))
                .ForPath(c => c.Hairdresser.HairdresserId, o => o.MapFrom(m => m.HairdresserId));

            this.CreateMap<Client, ClientModel>()
                .ForMember(c => c.ClientId, o => o.MapFrom(m => m.ClientId))
                .ForMember(c => c.ClientFirstName, o => o.MapFrom(m => m.FirstName))
                .ForMember(c => c.ClientLastName, o => o.MapFrom(m => m.LastName))
                .ForMember(c => c.ClientEmail, o => o.MapFrom(m => m.Email))
                .ForMember(c => c.ClientPhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                .ReverseMap();

            this.CreateMap<ClientModel, Client>();

            this.CreateMap<Salon, SalonModel>()
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.SalonId))
                .ForMember(c => c.SalonName, o => o.MapFrom(m => m.Name))
                .ForMember(c => c.SalonAddress, o => o.MapFrom(m => m.Address))
                .ForMember(c => c.SalonPhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                .ReverseMap();

            this.CreateMap<SalonModel, Salon>()
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.SalonId))
                .ForMember(c => c.Name, o => o.MapFrom(m => m.SalonName))
                .ForMember(c => c.Address, o => o.MapFrom(m => m.SalonAddress))
                .ForMember(c => c.PhoneNumber, o => o.MapFrom(m => m.SalonPhoneNumber))
                .ReverseMap();

            this.CreateMap<Hairdresser, HairdresserModel>()
                .ForMember(c => c.HairdresserId, o => o.MapFrom(m => m.HairdresserId))
                .ForMember(c => c.HairdresserFirstName, o => o.MapFrom(m => m.FirstName))
                .ForMember(c => c.HairdresserLastName, o => o.MapFrom(m => m.LastName))
                .ForMember(c => c.HairdresserPhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                .ForMember(c => c.HairdresserEmail, o => o.MapFrom(m => m.Email))
                .ForMember(c => c.HairdresserCategory, o => o.MapFrom(m => m.Category))
                .ForMember(c => c.SalonId, o => o.MapFrom(m => m.Salon.SalonId))
                .ReverseMap();
                //.ForMember(c=>c.Salon,opt=>opt.Ignore());

            this.CreateMap<HairdresserModel, Hairdresser>()
                .ForMember(c => c.FirstName, o => o.MapFrom(n => n.HairdresserFirstName))
                .ForMember(c => c.LastName, o => o.MapFrom(m => m.HairdresserLastName))
                .ForMember(c => c.PhoneNumber, o => o.MapFrom(m => m.HairdresserPhoneNumber))
                .ForMember(c => c.Email, o => o.MapFrom(m => m.HairdresserEmail))
                .ForMember(c => c.Category, o => o.MapFrom(m => m.HairdresserCategory))
                .ForPath(c => c.Salon.SalonId, o => o.MapFrom(m => m.SalonId))
                .ReverseMap();

        }
    }
}
