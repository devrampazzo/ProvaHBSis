using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaHBSIS.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    LivroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<int>(nullable: false),
                    NomeLivro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NomeAutor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Editora = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AnoLancamento = table.Column<int>(nullable: false),
                    Edicao = table.Column<byte>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livro_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Aventura" },
                    { 2, "Romance Nacional" },
                    { 3, "Romance Estrangeiro" },
                    { 4, "Terror" },
                    { 5, "Biografia" },
                    { 6, "Autobiografia" },
                    { 7, "Autoajuda" },
                    { 8, "Religião" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_CategoriaId",
                table: "Livro",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
