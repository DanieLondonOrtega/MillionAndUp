using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Infrastructure.Migrations
{
    public partial class CreateTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUser",
                schema: "dbo",
                columns: table => new
                {
                    Usuario = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUser",
                schema: "dbo");
        }
    }
}
