using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ampare.api.Migrations
{
    public partial class ProjetoVoluntariorRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Voluntarios_VoluntarioId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_VoluntarioId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "VoluntarioId",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Voluntarios",
                newName: "VoluntarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projetos",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ongs",
                newName: "OngId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProjetoVoluntario",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    VoluntarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoVoluntario", x => new { x.ProjetoId, x.VoluntarioId });
                    table.ForeignKey(
                        name: "FK_ProjetoVoluntario_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoVoluntario_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "VoluntarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoVoluntario_VoluntarioId",
                table: "ProjetoVoluntario",
                column: "VoluntarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoVoluntario");

            migrationBuilder.RenameColumn(
                name: "VoluntarioId",
                table: "Voluntarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Projetos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OngId",
                table: "Ongs",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoluntarioId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_VoluntarioId",
                table: "Projetos",
                column: "VoluntarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Voluntarios_VoluntarioId",
                table: "Projetos",
                column: "VoluntarioId",
                principalTable: "Voluntarios",
                principalColumn: "Id");
        }
    }
}
