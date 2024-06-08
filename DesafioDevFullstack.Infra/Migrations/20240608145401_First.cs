using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioDevFullstack.Infra.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TEndereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEndereco", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEndereco");
        }
    }
}
