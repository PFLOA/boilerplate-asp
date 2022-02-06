using Microsoft.EntityFrameworkCore.Migrations;

namespace Coladel.GerenciadorAulas.Migrations
{
    public partial class pagamento_idaula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "id_aula_pagamentos",
                table: "pagamentos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_pagamentos_id_aula_pagamentos",
                table: "pagamentos",
                column: "id_aula_pagamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_pagamentos_aulas_id_aula_pagamentos",
                table: "pagamentos",
                column: "id_aula_pagamentos",
                principalTable: "aulas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pagamentos_aulas_id_aula_pagamentos",
                table: "pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_pagamentos_id_aula_pagamentos",
                table: "pagamentos");

            migrationBuilder.DropColumn(
                name: "id_aula_pagamentos",
                table: "pagamentos");
        }
    }
}
