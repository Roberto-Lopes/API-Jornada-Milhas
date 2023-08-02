using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_alura_challenge.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "preço",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "foto",
                table: "Destinos",
                newName: "texto_descritivo");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Destinos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "foto_1",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "foto_2",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "meta",
                table: "Destinos",
                type: "varchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foto_1",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "foto_2",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "meta",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "texto_descritivo",
                table: "Destinos",
                newName: "foto");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Destinos",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "preço",
                table: "Destinos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
