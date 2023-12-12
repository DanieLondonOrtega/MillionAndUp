using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Infrastructure.Migrations
{
    public partial class ChangePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPropertyTrace",
                schema: "dbo",
                table: "tblPropertyTrace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPropertyImage",
                schema: "dbo",
                table: "tblPropertyImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPropertyTrace",
                schema: "dbo",
                table: "tblPropertyTrace",
                column: "IdPropertyTrace");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPropertyImage",
                schema: "dbo",
                table: "tblPropertyImage",
                column: "IdPropertyImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPropertyTrace",
                schema: "dbo",
                table: "tblPropertyTrace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPropertyImage",
                schema: "dbo",
                table: "tblPropertyImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPropertyTrace",
                schema: "dbo",
                table: "tblPropertyTrace",
                columns: new[] { "IdPropertyTrace", "IdProperty" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPropertyImage",
                schema: "dbo",
                table: "tblPropertyImage",
                columns: new[] { "IdPropertyImage", "IdProperty" });
        }
    }
}
