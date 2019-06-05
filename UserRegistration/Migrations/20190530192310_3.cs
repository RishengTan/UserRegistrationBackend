using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegistration.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Heros",
                "companyID",
                1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
