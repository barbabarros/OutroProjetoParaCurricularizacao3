using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curricularizacao.Migrations
{
    /// <inheritdoc />
    public partial class segundaversao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxParticipantes",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxParticipantes",
                table: "Atividades");
        }
    }
}
