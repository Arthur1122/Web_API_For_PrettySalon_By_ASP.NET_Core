using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pretty_Salon.Migrations
{
    public partial class SalonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.SalonId);
                });

            migrationBuilder.CreateTable(
                name: "Hairdressers",
                columns: table => new
                {
                    HairdresserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SalonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairdressers", x => x.HairdresserId);
                    table.ForeignKey(
                        name: "FK_Hairdressers_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<DateTime>(nullable: false),
                    TimeOfDay = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    HairdresserId = table.Column<int>(nullable: true),
                    SalonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrations_Hairdressers_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdressers",
                        principalColumn: "HairdresserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrations_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 1, "David Freeman" });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "SalonId", "Name" },
                values: new object[] { 1, "Pretty Salon 777" });

            migrationBuilder.InsertData(
                table: "Hairdressers",
                columns: new[] { "HairdresserId", "Name", "SalonId" },
                values: new object[] { 1, "Gil Markes", 1 });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "ClientId", "Day", "HairdresserId", "SalonId", "TimeOfDay" },
                values: new object[] { 1, 1, new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "03:00 PM" });

            migrationBuilder.CreateIndex(
                name: "IX_Hairdressers_SalonId",
                table: "Hairdressers",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ClientId",
                table: "Registrations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_HairdresserId",
                table: "Registrations",
                column: "HairdresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SalonId",
                table: "Registrations",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Hairdressers");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
