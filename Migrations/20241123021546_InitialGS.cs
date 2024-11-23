using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustenAI.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialGS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATE", nullable: false),
                    STATUS_ALERTA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA", x => x.ID_ALERTA);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISPOSITIVO",
                columns: table => new
                {
                    ID_DISPO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_DISPO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TIPO_DISPO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_INSTALACAO = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPOSITIVO", x => x.ID_DISPO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USER);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTA");

            migrationBuilder.DropTable(
                name: "TB_DISPOSITIVO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
