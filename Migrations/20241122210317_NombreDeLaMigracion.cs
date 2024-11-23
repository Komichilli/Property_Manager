using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _PropertyManager.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Propiedads_PropiedadId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquilinos_Propiedads_PropiedadId",
                table: "Inquilinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propiedads",
                table: "Propiedads");

            migrationBuilder.RenameTable(
                name: "Propiedads",
                newName: "Propiedades");

            migrationBuilder.AlterColumn<string>(
                name: "Disponible",
                table: "Propiedades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propiedades",
                table: "Propiedades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Propiedades_PropiedadId",
                table: "Contratos",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquilinos_Propiedades_PropiedadId",
                table: "Inquilinos",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Propiedades_PropiedadId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquilinos_Propiedades_PropiedadId",
                table: "Inquilinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propiedades",
                table: "Propiedades");

            migrationBuilder.RenameTable(
                name: "Propiedades",
                newName: "Propiedads");

            migrationBuilder.AlterColumn<bool>(
                name: "Disponible",
                table: "Propiedads",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propiedads",
                table: "Propiedads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Propiedads_PropiedadId",
                table: "Contratos",
                column: "PropiedadId",
                principalTable: "Propiedads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquilinos_Propiedads_PropiedadId",
                table: "Inquilinos",
                column: "PropiedadId",
                principalTable: "Propiedads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
