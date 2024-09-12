using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_API_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMotoRelacionadaColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locacaos_Motos_MotoRelacionadaId",
                table: "locacaos");

            migrationBuilder.DropIndex(
                name: "IX_locacaos_MotoRelacionadaId",
                table: "locacaos");

            migrationBuilder.DropColumn(
                name: "MotoRelacionadaId",
                table: "locacaos");

            migrationBuilder.CreateIndex(
                name: "IX_locacaos_IdMoto",
                table: "locacaos",
                column: "IdMoto");

            migrationBuilder.AddForeignKey(
                name: "FK_locacaos_Motos_IdMoto",
                table: "locacaos",
                column: "IdMoto",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locacaos_Motos_IdMoto",
                table: "locacaos");

            migrationBuilder.DropIndex(
                name: "IX_locacaos_IdMoto",
                table: "locacaos");

            migrationBuilder.AddColumn<int>(
                name: "MotoRelacionadaId",
                table: "locacaos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_locacaos_MotoRelacionadaId",
                table: "locacaos",
                column: "MotoRelacionadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_locacaos_Motos_MotoRelacionadaId",
                table: "locacaos",
                column: "MotoRelacionadaId",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
