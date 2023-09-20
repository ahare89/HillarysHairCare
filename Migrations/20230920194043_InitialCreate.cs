using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    StylistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentsServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    isEmployed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CustomerId", "Date", "StylistId" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "AppointmentsServices",
                columns: new[] { "Id", "AppointmentId", "ServiceId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Barry O'Bannon" },
                    { 2, "Michael O'Keefe" },
                    { 3, "Billy Smalls" },
                    { 4, "Mary O'Reilly" },
                    { 5, "Micah Swanson" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Women's Haircut", 30m },
                    { 2, "Shampoo", 20m },
                    { 3, "Men's Haircut", 15m },
                    { 4, "Beard Trim", 5m },
                    { 5, "Razor Shave", 10m },
                    { 6, "Hot Towel", 2m },
                    { 7, "Massage", 100m },
                    { 8, "Pedicure", 35m },
                    { 9, "Manicure", 25m },
                    { 10, "Perm", 80m },
                    { 11, "Color", 70m }
                });

            migrationBuilder.InsertData(
                table: "Stylists",
                columns: new[] { "Id", "Name", "isEmployed" },
                values: new object[,]
                {
                    { 1, "Yvonne Peterson", true },
                    { 2, "MichaelAnne Yarbrough", true },
                    { 3, "Kimmy Sanderson", true },
                    { 4, "Adrian Wizniowski", true },
                    { 5, "Pippa Vanderschnout", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentsServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Stylists");
        }
    }
}
