﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pretty_Salon.Data;

namespace Pretty_Salon.Migrations
{
    [DbContext(typeof(RegisterContext))]
    partial class RegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Email = "David@gmail.com",
                            FirstName = "David",
                            LastName = "Ghukasyan",
                            PhoneNumber = 96234233
                        });
                });

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Hairdresser", b =>
                {
                    b.Property<int>("HairdresserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.Property<int?>("SalonId");

                    b.HasKey("HairdresserId");

                    b.HasIndex("SalonId");

                    b.ToTable("Hairdressers");

                    b.HasData(
                        new
                        {
                            HairdresserId = 1,
                            Category = "Hairdressing",
                            FirstName = "Armen",
                            LastName = "Tadevosyan",
                            PhoneNumber = 97123456,
                            SalonId = 1
                        });
                });

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("Day");

                    b.Property<int?>("HairdresserId");

                    b.Property<int?>("SalonId");

                    b.Property<string>("TimeOfDay");

                    b.HasKey("RegistrationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("HairdresserId");

                    b.HasIndex("SalonId");

                    b.ToTable("Registrations");

                    b.HasData(
                        new
                        {
                            RegistrationId = 1,
                            ClientId = 1,
                            Day = new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HairdresserId = 1,
                            SalonId = 1,
                            TimeOfDay = "03:00 PM"
                        });
                });

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("SalonId");

                    b.ToTable("Salons");

                    b.HasData(
                        new
                        {
                            SalonId = 1,
                            Address = "Vernisaj 17/1",
                            Name = "Pretty Salon 777",
                            PhoneNumber = 10286543
                        });
                });

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Hairdresser", b =>
                {
                    b.HasOne("Pretty_Salon.Data.Entities.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");
                });

            modelBuilder.Entity("Pretty_Salon.Data.Entities.Registration", b =>
                {
                    b.HasOne("Pretty_Salon.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Pretty_Salon.Data.Entities.Hairdresser", "Hairdresser")
                        .WithMany()
                        .HasForeignKey("HairdresserId");

                    b.HasOne("Pretty_Salon.Data.Entities.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");
                });
#pragma warning restore 612, 618
        }
    }
}
