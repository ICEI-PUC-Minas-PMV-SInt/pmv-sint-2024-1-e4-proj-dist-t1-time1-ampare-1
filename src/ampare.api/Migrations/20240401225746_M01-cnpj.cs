using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ampare.api.Migrations
{
    public partial class M01cnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Cadastros",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Cadastros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Cadastros");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Cadastros");
        }
    }
}
