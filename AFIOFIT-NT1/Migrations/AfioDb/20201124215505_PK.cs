using Microsoft.EntityFrameworkCore.Migrations;

namespace AFIOFIT_NT1.Migrations.AfioDb
{
    public partial class PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCurso_ApplicationUser_UsuarioId",
                table: "UsuarioCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioCurso",
                table: "UsuarioCurso");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "UsuarioCurso",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsuarioCurso",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioCurso",
                table: "UsuarioCurso",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCurso_UsuarioId",
                table: "UsuarioCurso",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCurso_ApplicationUser_UsuarioId",
                table: "UsuarioCurso",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCurso_ApplicationUser_UsuarioId",
                table: "UsuarioCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioCurso",
                table: "UsuarioCurso");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCurso_UsuarioId",
                table: "UsuarioCurso");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsuarioCurso");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "UsuarioCurso",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioCurso",
                table: "UsuarioCurso",
                columns: new[] { "UsuarioId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCurso_ApplicationUser_UsuarioId",
                table: "UsuarioCurso",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
