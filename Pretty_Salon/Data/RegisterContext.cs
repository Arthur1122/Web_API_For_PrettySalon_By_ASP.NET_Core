using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pretty_Salon.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data
{
    public class RegisterContext :DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Client> Clients { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Salon> Salons { get; set; }


        public RegisterContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Register"));
        }

        protected override void OnModelCreating(ModelBuilder bdlr)
        {
            bdlr.Entity<Client>()
                .HasData(new
                {
                    ClientId = 1,
                    FirstName = "David",
                    LastName = "Ghukasyan",
                    Email = "David@gmail.com",
                    PhoneNumber = 096234233
                });

            bdlr.Entity<Hairdresser>()
                .HasData(new
                {
                    HairdresserId = 1,
                    FirstName = "Armen",
                    LastName = "Tadevosyan",
                    PhoneNumber = 097123456,
                    Category = "Hairdressing",
                    SalonId = 1
                });

            bdlr.Entity<Registration>()
                .HasData(new
                {
                    RegistrationId = 1,
                    Day = new  DateTime(2019,06,12),
                    TimeOfDay = "03:00 PM",
                    ClientId = 1,
                    HairdresserId = 1,
                    SalonId = 1
                });

            bdlr.Entity<Salon>()
                .HasData(new
                {
                    SalonId = 1,
                    Name = "Pretty Salon 777",
                    Address = "Vernisaj 17/1",
                    PhoneNumber = 010286543
                });

        }
    }
}

