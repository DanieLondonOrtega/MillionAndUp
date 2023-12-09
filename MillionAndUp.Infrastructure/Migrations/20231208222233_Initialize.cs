using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tblOwner",
                schema: "dbo",
                columns: table => new
                {
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOwner", x => x.IdOwner);
                });

            migrationBuilder.CreateTable(
                name: "tblProperty",
                schema: "dbo",
                columns: table => new
                {
                    IdProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CodeInternal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProperty", x => x.IdProperty);
                    table.ForeignKey(
                        name: "FK_tblProperty_tblOwner_IdOwner",
                        column: x => x.IdOwner,
                        principalSchema: "dbo",
                        principalTable: "tblOwner",
                        principalColumn: "IdOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPropertyImage",
                schema: "dbo",
                columns: table => new
                {
                    IdPropertyImage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPropertyImage", x => new { x.IdPropertyImage, x.IdProperty });
                    table.ForeignKey(
                        name: "FK_tblPropertyImage_tblProperty_IdProperty",
                        column: x => x.IdProperty,
                        principalSchema: "dbo",
                        principalTable: "tblProperty",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPropertyTrace",
                schema: "dbo",
                columns: table => new
                {
                    IdPropertyTrace = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPropertyTrace", x => new { x.IdPropertyTrace, x.IdProperty });
                    table.ForeignKey(
                        name: "FK_tblPropertyTrace_tblProperty_IdProperty",
                        column: x => x.IdProperty,
                        principalSchema: "dbo",
                        principalTable: "tblProperty",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProperty_IdOwner",
                schema: "dbo",
                table: "tblProperty",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_tblPropertyImage_IdProperty",
                schema: "dbo",
                table: "tblPropertyImage",
                column: "IdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_tblPropertyTrace_IdProperty",
                schema: "dbo",
                table: "tblPropertyTrace",
                column: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPropertyImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblPropertyTrace",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblProperty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblOwner",
                schema: "dbo");
        }
    }
}
