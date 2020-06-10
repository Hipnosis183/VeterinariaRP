using Microsoft.EntityFrameworkCore.Migrations;

namespace VeterinariaRP.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    TelCelular = table.Column<string>(maxLength: 20, nullable: false),
                    TelFijo = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
