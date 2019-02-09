using System;
using AcoesDotNet.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcoesDotNet.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoDaAcao = table.Column<string>(nullable: false),
                    DataCotacao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    TipoPessoa = table.Column<string>(nullable: false),
                    CnpjCpf = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoOrdem = table.Column<string>(nullable: false),
                    DataOrdem = table.Column<DateTime>(nullable: false),
                    QuantidadeAcoes = table.Column<int>(nullable: false),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    ValorOrdem = table.Column<decimal>(nullable: false),
                    TaxaCorretagem = table.Column<decimal>(nullable: false),
                    ImpostoRenda = table.Column<decimal>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    CodigoAcao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordens_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Ordens_ClienteId",
                table: "Ordens",
                column: "ClienteId");

            migrationBuilder.Sql($"ALTER TABLE Clientes ADD CONSTRAINT ck_clientes CHECK ({nameof(Cliente.TipoPessoa)} IN ('{(Cliente.TIPO_PESSOA_FISICA)}','{Cliente.TIPO_PESSOA_JURIDICA}'))");
            migrationBuilder.Sql($"ALTER TABLE Ordens   ADD CONSTRAINT ck_ordens   CHECK ({nameof(Ordem.TipoOrdem)}    IN ('{Ordem.TIPO_COMPRA}','{Ordem.TIPO_VENDA}'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "Ordens");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
