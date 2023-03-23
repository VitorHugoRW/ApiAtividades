using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtividadeApi.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HorasAtividade",
                table: "Atividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasAtividade",
                table: "Atividades");
        }
    }
}
