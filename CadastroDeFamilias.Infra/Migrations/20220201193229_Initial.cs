using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeFamilias.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mae",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<double>(type: "float", maxLength: 6, nullable: true),
                    Peso = table.Column<double>(type: "float", maxLength: 6, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    PapelUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mae", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NomeLogin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PapelUsuario = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Altura = table.Column<double>(type: "float", maxLength: 6, nullable: false),
                    Peso = table.Column<double>(type: "float", maxLength: 6, nullable: false),
                    IdMae = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filho_Mae_IdMae",
                        column: x => x.IdMae,
                        principalTable: "Mae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<double>(type: "float", maxLength: 6, nullable: true),
                    Peso = table.Column<double>(type: "float", maxLength: 6, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PapelUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMae = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pai_Mae_IdMae",
                        column: x => x.IdMae,
                        principalTable: "Mae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Email", "NomeCompleto", "NomeLogin", "PapelUsuario", "Senha" },
                values: new object[] { 1, true, "dev.brunolima@hotmail.com", "ADM MASTER", "admin", 0, "admin123" });

            migrationBuilder.CreateIndex(
                name: "IX_Filho_IdMae",
                table: "Filho",
                column: "IdMae");

            migrationBuilder.CreateIndex(
                name: "IX_Pai_IdMae",
                table: "Pai",
                column: "IdMae",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filho");

            migrationBuilder.DropTable(
                name: "Pai");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Mae");
        }
    }
}
