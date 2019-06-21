using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegistration.Migrations.Client
{
    public partial class MDNdemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table1",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table1", x => x.FirstName);
                });

            migrationBuilder.CreateTable(
                name: "table2",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    LicenseNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table2", x => x.FirstName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table1");

            migrationBuilder.DropTable(
                name: "table2");
        }
    }
}
