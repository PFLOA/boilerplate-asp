using Microsoft.EntityFrameworkCore.Migrations;

namespace Coladel.GerenciadorAulas.Migrations
{
    public partial class data_aula_is : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "is_cancelada",
                table: "aulas",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "is_realizada",
                table: "aulas",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_cancelada",
                table: "aulas");

            migrationBuilder.DropColumn(
                name: "is_realizada",
                table: "aulas");
        }
    }
}
