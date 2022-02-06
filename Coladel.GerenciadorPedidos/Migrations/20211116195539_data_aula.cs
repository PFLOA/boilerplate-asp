using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coladel.GerenciadorAulas.Migrations
{
    public partial class data_aula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_aula",
                table: "aulas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_aula",
                table: "aulas");
        }
    }
}
