using Microsoft.EntityFrameworkCore.Migrations;

namespace AFIOFIT_NT1.Migrations.AfioDb
{
    public partial class CursosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Disponible = table.Column<bool>(nullable: false),
                    Descuento = table.Column<double>(nullable: false),
                    Categoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
