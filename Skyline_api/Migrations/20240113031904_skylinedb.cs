using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skyline_api.Migrations
{
    public partial class skylinedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    aeroporto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADE", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mensagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    resolvido = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.cpf);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VOO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_voo = table.Column<int>(type: "int", nullable: false),
                    comp_aerea = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    assentos = table.Column<int>(type: "int", nullable: false),
                    preco_unit = table.Column<double>(type: "double", nullable: false),
                    data_partida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    origem_id = table.Column<int>(type: "int", nullable: false),
                    destino_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOO", x => x.id);
                    table.ForeignKey(
                        name: "FK_VOO_CIDADE_destino_id",
                        column: x => x.destino_id,
                        principalTable: "CIDADE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOO_CIDADE_origem_id",
                        column: x => x.origem_id,
                        principalTable: "CIDADE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RESERVA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_reserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    num_pessoas = table.Column<int>(type: "int", nullable: false),
                    cancelada = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false),
                    usuario_cpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    voo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVA", x => x.id);
                    table.ForeignKey(
                        name: "FK_RESERVA_USUARIO_usuario_cpf",
                        column: x => x.usuario_cpf,
                        principalTable: "USUARIO",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESERVA_VOO_voo_id",
                        column: x => x.voo_id,
                        principalTable: "VOO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_usuario_cpf",
                table: "RESERVA",
                column: "usuario_cpf");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_voo_id",
                table: "RESERVA",
                column: "voo_id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_email",
                table: "USUARIO",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VOO_destino_id",
                table: "VOO",
                column: "destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_VOO_origem_id",
                table: "VOO",
                column: "origem_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "RESERVA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "VOO");

            migrationBuilder.DropTable(
                name: "CIDADE");
        }
    }
}
