using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zeynerp.Infrastructure.Data.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class _05062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cariler_CariYetkililer_CariYetkiliId",
                table: "Cariler");

            migrationBuilder.DropForeignKey(
                name: "FK_Cariler_TeslimatAdresleri_TeslimatAdresId",
                table: "Cariler");

            migrationBuilder.DropIndex(
                name: "IX_Cariler_CariYetkiliId",
                table: "Cariler");

            migrationBuilder.DropIndex(
                name: "IX_Cariler_TeslimatAdresId",
                table: "Cariler");

            migrationBuilder.DropColumn(
                name: "CariYetkiliId",
                table: "Cariler");

            migrationBuilder.DropColumn(
                name: "TeslimatAdresId",
                table: "Cariler");

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "TeslimatAdresleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "CariYetkililer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeslimatAdresleri_CariId",
                table: "TeslimatAdresleri",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariYetkililer_CariId",
                table: "CariYetkililer",
                column: "CariId");

            migrationBuilder.AddForeignKey(
                name: "FK_CariYetkililer_Cariler_CariId",
                table: "CariYetkililer",
                column: "CariId",
                principalTable: "Cariler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeslimatAdresleri_Cariler_CariId",
                table: "TeslimatAdresleri",
                column: "CariId",
                principalTable: "Cariler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariYetkililer_Cariler_CariId",
                table: "CariYetkililer");

            migrationBuilder.DropForeignKey(
                name: "FK_TeslimatAdresleri_Cariler_CariId",
                table: "TeslimatAdresleri");

            migrationBuilder.DropIndex(
                name: "IX_TeslimatAdresleri_CariId",
                table: "TeslimatAdresleri");

            migrationBuilder.DropIndex(
                name: "IX_CariYetkililer_CariId",
                table: "CariYetkililer");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "TeslimatAdresleri");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "CariYetkililer");

            migrationBuilder.AddColumn<int>(
                name: "CariYetkiliId",
                table: "Cariler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeslimatAdresId",
                table: "Cariler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cariler_CariYetkiliId",
                table: "Cariler",
                column: "CariYetkiliId");

            migrationBuilder.CreateIndex(
                name: "IX_Cariler_TeslimatAdresId",
                table: "Cariler",
                column: "TeslimatAdresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cariler_CariYetkililer_CariYetkiliId",
                table: "Cariler",
                column: "CariYetkiliId",
                principalTable: "CariYetkililer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cariler_TeslimatAdresleri_TeslimatAdresId",
                table: "Cariler",
                column: "TeslimatAdresId",
                principalTable: "TeslimatAdresleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
