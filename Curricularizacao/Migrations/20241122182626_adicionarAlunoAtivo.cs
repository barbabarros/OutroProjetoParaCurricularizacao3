using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curricularizacao.Migrations
{
    /// <inheritdoc />
    public partial class adicionarAlunoAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Alunos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Alunos");
        }
    }
}
